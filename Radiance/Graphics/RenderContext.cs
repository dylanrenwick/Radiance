using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Radiance.Graphics
{
    public class RenderContext
    {
        private const int FONT_SIZE = 144;

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

        public void Begin() => this.sb.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);
        public void End() => this.sb.End();

        public void DrawLine(Point start, Point end, Color color, float thickness = 1f)
        {
            float length = Vector2.Distance(new Vector2(start.X, start.Y), new Vector2(end.X, end.Y));
            float angle = this.Rad2Deg((float)Math.Atan2(end.Y - start.Y, end.X - start.X));

            this.DrawLine(start, length, angle, color, thickness);
        }
        public void DrawLine(Point start, float length, float angle, Color color, float thickness = 1f)
        {
            if (length == 0) length = 1;
            this.DrawTexture(this.pixel, start, color, angle, Point.Zero, new Vector2(length, thickness));
        }

        public void DrawRect(Rectangle rect, Color color, float thickness = 1f)
        {
            this.DrawLine(rect.Location, new Point(rect.X + rect.Width, rect.Y), color, thickness);
            this.DrawLine(new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height), color, thickness);
            this.DrawLine(new Point(rect.X + rect.Width, rect.Y + rect.Height), new Point(rect.X, rect.Y + rect.Height), color, thickness);
            this.DrawLine(new Point(rect.X, rect.Y + rect.Height), rect.Location, color, thickness);
        }

        public void DrawTexture(Texture2D tex, Point position, Color color)
        {
            var destRect = new Rectangle(position, new Point(tex.Width, tex.Height));
            this.DrawTexture(tex, destRect, null, color, 0f, Vector2.One, Vector2.Zero);
        }
        public void DrawTexture(Texture2D tex, Point position, Color color, float rotation)
        {
            var destRect = new Rectangle(position, new Point(tex.Width, tex.Height));
            this.DrawTexture(tex, destRect, null, color, rotation, Vector2.One, Vector2.Zero);
        }
        public void DrawTexture(Texture2D tex, Rectangle destRect, Color color)
        {
            this.DrawTexture(tex, destRect, null, color, 0f, Vector2.One, Vector2.Zero);
        }
        public void DrawTexture(Texture2D tex, Rectangle destRect, Rectangle? sourceRect, Color color, float rotation, Vector2 scale, Vector2 origin, SpriteEffects spriteEffects = SpriteEffects.None, float layerDepth = 0f)
        {
            if (tex == null) tex = this.pixel;
            destRect.Location -= this.MainCamera.Position;
            if (!sourceRect.HasValue) sourceRect = new Rectangle(0, 0, tex.Width * (int)scale.X, tex.Height * (int)scale.Y);
            this.sb.Draw(tex, destRect, sourceRect, color, this.Deg2Rad(rotation), origin, spriteEffects, layerDepth);
        }
        public void DrawTexture(Texture2D tex, Point position, Color color, float rotation, Point origin)
        {
            this.DrawTexture(tex, position, color, rotation, origin, Vector2.One);
        }
        public void DrawTexture(Texture2D tex, Point position, Color color, float angle, Point origin, Vector2 scale, SpriteEffects spriteEffects = SpriteEffects.None, float layerDepth = 0f)
        {
            this.sb.Draw(tex, new Vector2(position.X, position.Y), null, color, this.Deg2Rad(angle), new Vector2(origin.X, origin.Y), scale, spriteEffects, layerDepth);
        }

        public void DrawText(string text, Point position, Color color, int fontSize, Rectangle bounds, TextHoriAlign horiAlign = TextHoriAlign.Left, TextVertAlign vertAlign = TextVertAlign.Bottom)
        {
            float scale = (float)fontSize / RenderContext.FONT_SIZE;
            this.DrawText(text, position, color, bounds, 0f, Point.Zero, scale, horiAlign, vertAlign);
        }
        public void DrawText(string text, Point position, Color color, Rectangle? bounds, float rotation, Point origin, float scale, TextHoriAlign horiAlign = TextHoriAlign.Left, TextVertAlign vertAlign = TextVertAlign.Bottom, SpriteEffects spriteEffects = SpriteEffects.None, float layerDepth = 0f)
        {
            Vector2 textSize = this.Font.MeasureString(text);
            textSize = new Vector2(textSize.X * scale, textSize.Y * scale);

            if (bounds == null)
            {
                bounds = new Rectangle(origin, new Point((int)Math.Ceiling(textSize.X), (int)Math.Ceiling(textSize.Y)));
            }

            Vector2 vOrigin = new Vector2(0, 0);

            switch (horiAlign)
            {
                case TextHoriAlign.Left:
                    vOrigin.X = origin.X;
                    break;
                case TextHoriAlign.Middle:
                    vOrigin.X -= origin.X - (bounds.Value.Width / 2 - textSize.X / 2);
                    break;
                case TextHoriAlign.Right:
                    vOrigin.X -= origin.X - (bounds.Value.Width - textSize.X);
                    break;
            }
            switch (vertAlign)
            {
                case TextVertAlign.Top:
                    vOrigin.Y -= origin.Y;
                    break;
                case TextVertAlign.Middle:
                    vOrigin.Y -= origin.Y - (bounds.Value.Height / 2 - textSize.Y / 2);
                    break;
                case TextVertAlign.Bottom:
                    vOrigin.Y -= origin.Y - (bounds.Value.Height - textSize.Y);
                    break;
            }

            this.sb.DrawString(this.Font, text, new Vector2(position.X, position.Y) + vOrigin, color, rotation, Vector2.Zero, scale, spriteEffects, layerDepth);
        }

        private float Rad2Deg(float rad) => rad * (180 / (float)Math.PI);
        private float Deg2Rad(float deg) => deg / (180 / (float)Math.PI);
    }

    public enum TextVertAlign
    {
        Top, Middle, Bottom
    }
    public enum TextHoriAlign
    {
        Left, Middle, Right
    }
}
