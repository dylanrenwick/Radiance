using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiSouls.Graphics;
using Microsoft.Xna.Framework;

namespace DigiSouls.Components.UI
{
    public class UISlider : UIPanel
    {
        public float MaxValue { get; set; }
        public float Value { get; set; }
        public Color FillColor { get; set; }
        public float NormalizedValue
        {
            get => this.Value / this.MaxValue;
            set => this.Value = value * this.MaxValue;
        }

        public UISlider(float maxValue, float value, Color? fillColor) : base()
        {
            this.MaxValue = maxValue;
            this.Value = value;
            if (!fillColor.HasValue) fillColor = Color.White;
            this.FillColor = fillColor.Value;
        }

        public override void Draw(RenderContext g, GameTime time)
        {
            base.Draw(g, time);
            Rectangle rect = this.Rect;
            rect.Width = (int)Math.Round(this.NormalizedValue * rect.Width);
            g.DrawTexture(null, rect, this.FillColor);
        }
    }
}
