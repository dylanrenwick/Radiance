using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using DigiSouls.Events;
using Newtonsoft.Json.Linq;

namespace DigiSouls.Components.UI
{
    public abstract class UIComponent : Component
    {
        public RectTransform RectTransform
        {
            get => this.Transform as RectTransform;
            set => this.Transform = value as Transform;
        }

        public Rectangle Rect => this.RectTransform.Rect;

        public UIComponent(Component parent = null): base(parent) { }
        public UIComponent(JObject json): base(json) { }

        protected override Transform CreateTransform(JObject json = null)
        {
            if (json != null) return new RectTransform(this, json);
            return new RectTransform(this);
        }

        public override void OnMouseDown(MouseEventArgs e)
        {
            if (this.RectTransform.Contains(e.Location)) this.OnUIMouseDown(e);
            base.OnMouseDown(e);
        }
        public override void OnMouseUp(MouseEventArgs e)
        {
            if (this.RectTransform.Contains(e.Location)) this.OnUIMouseUp(e);
            base.OnMouseUp(e);
        }
        public override void OnMouseMove(MouseEventArgs e)
        {
            if (this.RectTransform.Contains(e.Location) && !this.RectTransform.Contains(e.OldLocation)) this.OnUIMouseEnter(e);
            else if (!this.RectTransform.Contains(e.Location) && this.RectTransform.Contains(e.OldLocation)) this.OnUIMouseExit(e);
        }

        public virtual void OnUIMouseDown(MouseEventArgs e) { }
        public virtual void OnUIMouseUp(MouseEventArgs e) { }
        public virtual void OnUIMouseEnter(MouseEventArgs e) { }
        public virtual void OnUIMouseExit(MouseEventArgs e) { }
    }
}
