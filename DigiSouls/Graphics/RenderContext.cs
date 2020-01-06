using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DigiSouls.Graphics
{
    public class RenderContext
    {
        private Texture2D pixel;
        private SpriteBatch sb;

        public Camera MainCamera { get; set; }
        public SpriteFont Font { get; set; }

        public GraphicsDevice GraphicsDevice => this.sb.GraphicsDevice;

        public RenderContext(SpriteBatch sb)
        {
            this.sb = sb;

            this.pixel = new Texture2D(this.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            this.pixel.SetData(new Color[] { Color.White });
        }

        public void Begin() => this.sb.Begin();
        public void End() => this.sb.End();

        public void DrawLine(Point start, Point end, Color color, float thickness = 1f)
        {
            float length = Vector2.Distance(new Vector2(start.X, start.Y), new Vector2(end.X, end.Y));
            float angle = (float)Math.Atan2(end.Y - start.Y, end.X - start.X);

            this.DrawLine(start, length, angle, color, thickness);
        }
        public void DrawLine(Point start, float length, float angle, Color color, float thickness = 1f)
        {
            this.DrawTexture(this.pixel, start, color, angle, Point.Zero, new Vector2(length, thickness));
        }

        public void DrawTexture(Texture2D tex, Point position, Color color)
        {
            var destRect = new Rectangle(position, new Point(tex.Width, tex.Height));
            this.DrawTexture(tex, destRect, null, color, 0f, Vector2.One);
        }
        public void DrawTexture(Texture2D tex, Rectangle destRect, Color color)
        {
            this.DrawTexture(tex, destRect, null, color, 0f, Vector2.One);
        }
        public void DrawTexture(Texture2D tex, Rectangle destRect, Rectangle? sourceRect, Color color, float rotation, Vector2 scale, SpriteEffects spriteEffects = SpriteEffects.None, float layerDepth = 0f)
        {
            if (tex == null) tex = this.pixel;
            destRect.Location -= this.MainCamera.Position;
            if (!sourceRect.HasValue) sourceRect = new Rectangle(0, 0, tex.Width, tex.Height);
            this.sb.Draw(tex, destRect, sourceRect, color, rotation, scale, spriteEffects, layerDepth);
        }
        public void DrawTexture(Texture2D tex, Point position, Color color, float angle, Point origin, Vector2 scale, SpriteEffects spriteEffects = SpriteEffects.None, float layerDepth = 0f)
        {

        }

        public void DrawText(string text, Point position, Color color)
        {
            this.sb.DrawString(this.Font, text, new Vector2(position.X, position.Y), color);
        }
    }
}
