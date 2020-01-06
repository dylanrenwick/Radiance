using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;

namespace Radiance.Assets
{
    public class Font : Asset
    {
        private SpriteFont inner;

        public Font(string name, SpriteFont inner) : base(name)
        {
            this.inner = inner;
        }

        public static Asset Deserialize(string name) => Assets.LoadFont(name);

        public static implicit operator SpriteFont(Font f) => f?.inner;
    }
}
