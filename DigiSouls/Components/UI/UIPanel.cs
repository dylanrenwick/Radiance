using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Newtonsoft.Json.Linq;

using DigiSouls.Graphics;
using DigiSouls.Serialization;

using DigiSouls.Assets;

namespace DigiSouls.Components.UI
{
    public class UIPanel : UIComponent, IRenderable
    {
        [SerializedField]
        public Texture2D Texture;
        public Color Color;

        public UIPanel() : base() { }
        public UIPanel(JObject json) : base(json) { }

        public void Draw(RenderContext g, GameTime time)
        {
            g.DrawTexture(this.Texture, this.RectTransform.Rect, this.Color);
        }

        public override JClass Serialize()
        {
            return base.Serialize();
        }
    }
}
