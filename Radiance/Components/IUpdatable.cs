using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiance.Components

{
    public interface IUpdatable
    {
        void Update(Input input);
    }
}
