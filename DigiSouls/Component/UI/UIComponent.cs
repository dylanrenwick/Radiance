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

        public UIComponent(Component parent = null): base(parent)
        { }

        protected override Transform CreateTransform()
        {
            return new RectTransform(this);
        }
    }
}
