using Microsoft.Xna.Framework;
using MG_Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

namespace Radiance.Assets
{
    public class Texture2D : Asset
    {
        private MG_Texture2D inner;

        public int Width => inner.Width;
        public int Height => inner.Height;

        public Point Origin { get; set; }

        public Texture2D(string name, MG_Texture2D inner, OriginType originType) : base(name)
        {
            this.inner = inner;
            switch (originType)
            {
                case OriginType.TopRight:
                    this.Origin = new Point(this.Width, 0);
                    break;
                case OriginType.BottomLeft:
                    this.Origin = new Point(0, this.Height);
                    break;
                case OriginType.BottomRight:
                    this.Origin = new Point(this.Width, this.Height);
                    break;
                case OriginType.Center:
                    this.Origin = new Point(this.Width / 2, this.Height / 2);
                    break;
                default:
                    this.Origin = Point.Zero;
                    break;
            }
        }

        public static Asset Deserialize(string name) => Assets.LoadTexture2D(name);

        public static implicit operator MG_Texture2D(Texture2D tex) => tex?.inner;
    }
}
