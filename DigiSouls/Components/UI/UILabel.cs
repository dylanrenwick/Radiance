using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using DigiSouls.Graphics;

namespace DigiSouls.Components.UI
{
    public class UILabel : UIComponent, IRenderable
    {
        public string Text { get; set; }
        public Color Color { get; set; }
        public int FontSize { get; set; }
        public TextHoriAlign HorizontalAlign { get; set; }
        public TextVertAlign VerticalAlign { get; set; }

        public UILabel() : base() { }

        public void Draw(RenderContext g, GameTime gameTime)
        {
            g.DrawText(this.Text, this.Transform.PointPosition, this.Color, this.FontSize, this.Rect, this.HorizontalAlign, this.VerticalAlign);
        }
    }
}
