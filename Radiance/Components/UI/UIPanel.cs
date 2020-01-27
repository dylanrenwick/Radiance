using Microsoft.Xna.Framework;

using Radiance.Graphics;
using Radiance.Assets;

namespace Radiance.Components.UI
{
    public class UIPanel : UIComponent, IRenderable
    {
        public Texture2D Texture;
        public Color Color;

        public UIPanel() : base() { }

        public virtual void Draw(RenderContext g)
        {
            g.DrawTexture(this.Texture, this.RectTransform.Rect, this.Color);
        }
    }
}
