using System.Linq;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using DigiSouls.Serialization;

namespace DigiSouls.Component
{
    public abstract class Component : JsonSerializable
    {
        public bool Active { get; set; }
        public Component Parent { get; set; }
        public Transform Transform { get; protected set; }

        private List<Component> children;

        public Component(Component parent = null, Transform transform = null)
        {
            this.Active = true;
            this.Parent = parent;
            this.children = new List<Component>();
            this.Transform = transform ?? this.CreateTransform();
        }
        public Component(JObject obj)
        {
            this.Active = obj.Value<bool>("Active");
            this.Transform = this.CreateTransform(obj["Transform"] as JObject);
            this.children = Serializer.DeserializeArray(obj["Children"] as JArray).Cast<Component>().ToList();
            children.ForEach(c => c.Parent = this);
        }

        public T AddComponent<T>(T c) where T : Component
        {
            if (!this.children.Contains(c))
            {
                c.Parent = this;
                this.children.Add(c);
            }
            return c;
        }

        public T GetComponent<T>() where T : Component
        {
            return this.children.Where(o => o is T).FirstOrDefault() as T;
        }

        public void RemoveComponent<T>(T c) where T : Component
        {
            this.children.Remove(c);
        }

        protected virtual Transform CreateTransform(JObject json = null)
        {
            if (json != null)
            {
                return new Transform(this, json);
            }
            return new Transform(this);
        }

        public override JClass Serialize()
        {
            var jObj = new JClass(this);
            jObj.Add("Transform", this.Transform.Serialize());
            jObj.Add("Children", new JArray(this.children.Select(c => c.Serialize()).ToArray()));
            jObj.Add("Active", this.Active);
            return jObj;
        }
    }
}
