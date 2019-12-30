using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiSouls.Component.UI
{
    public abstract class UIComponent : Component
    {
        public RectTransform RectTransform
        {
            get => this.Transform as RectTransform;
            set => this.Transform = value as Transform;
        }

        public UIComponent(Component parent = null): base(parent) { }
        public UIComponent(JObject json): base(json) { }

        protected override Transform CreateTransform(JObject json = null)
        {
            if (json != null) return new RectTransform(this, json);
            return new RectTransform(this);
        }
    }
}
