using DigiSouls.Serialization;
using Microsoft.Xna.Framework;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiSouls.Component.UI
{
    public class RectTransform : Transform
    {
        public Vector2 Size { get; set; }

        public Rectangle Rect
        {
            get => new Rectangle((int)this.Position.X, (int)this.Position.Y, (int)this.Size.X, (int)this.Size.Y);
            set
            {
                this.LocalPosition = new Vector3(value.X, value.Y, this.LocalPosition.Z);
                this.Size = new Vector2(value.Width, value.Height);
            }
        }

        public RectTransform(Component parent): base(parent) { }
        public RectTransform(Component parent, JObject json): base(parent, json)
        {
            this.Size = Serializer.DeserializeVector2(json["Size"] as JObject);
        }

        public override JClass Serialize()
        {
            JClass jObj = base.Serialize();
            jObj.Add("Size", this.Size.Serialize());
            return jObj;
        }
    }
}
