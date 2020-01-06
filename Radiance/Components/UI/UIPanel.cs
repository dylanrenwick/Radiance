using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Newtonsoft.Json.Linq;

using Radiance.Graphics;
using Radiance.Serialization;

using Radiance.Assets;

namespace Radiance.Components.UI
{
    public class UIPanel : UIComponent, IRenderable
    {
        [SerializedField]
        public Texture2D Texture;
        public Color Color;

        public UIPanel() : base() { }
        public UIPanel(JObject json) : base(json) { }

        public virtual void Draw(RenderContext g, GameTime time)
        {
            g.DrawTexture(this.Texture, this.RectTransform.Rect, this.Color);
        }

        public override JClass Serialize()
        {
            return base.Serialize();
        }
    }
}
