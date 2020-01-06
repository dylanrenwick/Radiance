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

        public override void Draw(RenderContext g, GameTime time)
        {
            base.Draw(g, time);
            g.DrawText(this.Text, new Point((int)this.Transform.Position.X, (int)this.Transform.Position.Y), this.TextColor);
        }

        public override void OnMouseDown(MouseEventArgs e)
        {
            if (this.RectTransform.Contains(e.Location))
            {
                this.OnClick?.Invoke(e);
            }
            base.OnMouseDown(e);
        }
    }
}
