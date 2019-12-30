using DigiSouls.Serialization;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiSouls.Component.UI
{
    public class RectTransform : Transform
    {
        public Vector2 Size { get; set; }

        public Rectangle Rect => new Rectangle((int)this.Position.X, (int)this.Position.Y, (int)this.Size.X, (int)this.Size.Y);

        public RectTransform(Component parent): base(parent)
        { }

        public override JClass Serialize()
        {
            var jObj = base.Serialize();
            jObj.Add("W", this.Size.X);
            jObj.Add("H", this.Size.Y);
            return jObj;
        }
    }
}
