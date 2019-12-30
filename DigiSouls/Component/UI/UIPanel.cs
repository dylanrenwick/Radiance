using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DigiSouls.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json.Linq;

using DigiSouls.Graphics;

namespace DigiSouls.Component.UI
{
    public class UIPanel : UIComponent, IRenderable
    {
        public Texture2D Texture;
        public Color Color;

        public UIPanel() : base() { }
        public UIPanel(JObject json) : base(json) { }

        public void Draw(SpriteBatch sb, GameTime time)
        {
            if (this.Texture != null) sb.Draw(this.Texture, this.RectTransform.Rect, this.Color);
            else sb.FillRectangle(this.RectTransform.Rect, this.Color);
        }

        public override JClass Serialize()
        {
            return base.Serialize();
        }
    }
}
