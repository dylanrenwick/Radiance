using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiSouls.Graphics
{
    public static class Primitives
    {
        private static Texture2D pixel;

        public static void Init(SpriteBatch sb)
        {
            pixel = new Texture2D(sb.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new Color[] { Color.White });
        }

        public static void FillRectangle(this SpriteBatch sb, Rectangle rect, Color color)
        {
            sb.Draw(pixel, rect, color);
        }
        public static void FillRectangle(this SpriteBatch sb, Rectangle rect, Color color, float angle)
        {
            sb.Draw(pixel, rect, null, color, angle, Vector2.Zero, SpriteEffects.None, 0);
        }
    }
}
