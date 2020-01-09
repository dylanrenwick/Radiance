using Microsoft.Xna.Framework;

namespace Radiance.Components.UI
{
    public class RectTransform : Transform
    {
        public Vector2 Size { get; set; }

        public Rectangle Rect
        {
            get => new Rectangle((int)this.Position.X, (int)this.Position.Y, (int)this.Size.X, (int)this.Size.Y);
            set
            {
                this.LocalPosition = new Vector3(value.X, value.Y, this.LocalPosition.Z);
                this.Size = new Vector2(value.Width, value.Height);
            }
        }

        public RectTransform(Component parent): base(parent) { }

        public bool Contains(Point p) => this.Rect.Contains(p);
        public bool Contains(int x, int y) => this.Rect.Contains(x, y);
    }
}
