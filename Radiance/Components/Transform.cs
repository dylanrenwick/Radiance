using Microsoft.Xna.Framework;

using Radiance.Serialization;

namespace Radiance.Components

{
    public class Transform
    {
        public Vector3 LocalPosition;
        public float LocalRotation;

        public Component Parent { get; private set; }

        public Transform ParentTransform
        {
            get
            {
                var parentComponent = this.Parent.Parent;
                if (parentComponent == null) return null;
                return parentComponent.Transform;
            }
        }

        public Vector3 Position => this.ParentTransform == null ? this.LocalPosition : this.ParentTransform.Position + this.LocalPosition;
        public float Rotation => this.ParentTransform == null ? this.LocalRotation : this.ParentTransform.Rotation + this.LocalRotation;

        public Point PointPosition => new Point((int)this.Position.X, (int)this.Position.Y);

        public Transform(Component parent)
        {
            this.Parent = parent;
        }
    }
}
