using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Radiance.Graphics;

namespace Radiance.Components

{
    public interface IRenderable
    {
        void Draw(RenderContext g, GameTime time);
    }
}
