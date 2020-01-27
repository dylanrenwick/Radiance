using Microsoft.Xna.Framework;

using Radiance.Events;
using Radiance.Graphics;
using static Radiance.Input;

namespace Radiance.Components.UI
{
    public class UIButton : UIPanel
    {
        public event MouseEventHandler OnClick;

        public string Text { get; set; }
        public Color TextColor { get; set; }
        public Color HoverColor { get; set; }
        public TextHoriAlign HorizontalAlign { get; set; }
        public TextVertAlign VerticalAlign { get; set; }

        private bool isHover;

        public UIButton() : base()
        {
            this.HorizontalAlign = TextHoriAlign.Middle;
            this.VerticalAlign = TextVertAlign.Middle;
            this.HoverColor = new Color(1f, 1f, 1f, 0.3f);
        }

        public override void Draw(RenderContext g)
        {
            base.Draw(g);
            if (this.isHover) g.DrawTexture(this.Texture, this.Rect, this.HoverColor);
            g.DrawText(this.Text, new Point((int)this.Transform.Position.X, (int)this.Transform.Position.Y), this.TextColor, 24, this.Rect, this.HorizontalAlign, this.VerticalAlign);
        }

        public override void OnUIMouseUp(MouseEventArgs e)
        {
            this.OnClick?.Invoke(e);
            base.OnUIMouseUp(e);
        }

        public override void OnUIMouseEnter(MouseEventArgs e)
        {
            this.isHover = true;
            base.OnUIMouseEnter(e);
        }
        public override void OnUIMouseExit(MouseEventArgs e)
        {
            this.isHover = false;
            base.OnUIMouseExit(e);
        }
    }
}
