using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DigiSouls.Graphics;

namespace DigiSouls.Components

{
    public interface IRenderable
    {
        void Draw(RenderContext g, GameTime time);
    }
}
