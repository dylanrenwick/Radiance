using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace DigiSouls.Components

{
    public interface IRenderable
    {
        void Draw(SpriteBatch sb, GameTime time);
    }
}
