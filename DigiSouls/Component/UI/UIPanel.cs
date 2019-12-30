using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DigiSouls.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DigiSouls.Component.UI
{
    public class UIPanel : UIComponent, IRenderable
    {
        public Texture2D Texture;

        public void Draw(SpriteBatch sb, GameTime time)
        {
            sb.Draw(this.Texture, this.RectTransform.Rect, Color.White);
        }

        public override JClass Serialize()
        {
            return base.Serialize();
        }
    }
}
