using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiSouls.Events;
using DigiSouls.Graphics;
using DigiSouls.Serialization;
using Microsoft.Xna.Framework;
using static DigiSouls.Input;

namespace DigiSouls.Components.UI
{
    public class UIButton : UIPanel
    {
        public event MouseEventHandler OnClick;

        [SerializedField]
        public string Text { get; set; }
        [SerializedField]
        public Color TextColor { get; set; }
        [SerializedField]
        public Color HoverColor { get; set; }
        [SerializedField]
        public TextHoriAlign HorizontalAlign { get; set; }
        [SerializedField]
        public TextVertAlign VerticalAlign { get; set; }

        private bool isHover;

        public UIButton() : base()
        {
            this.HorizontalAlign = TextHoriAlign.Middle;
            this.VerticalAlign = TextVertAlign.Middle;
            this.HoverColor = new Color(1f, 1f, 1f, 0.3f);
        }

        public override void Draw(RenderContext g, GameTime time)
        {
            base.Draw(g, time);
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
