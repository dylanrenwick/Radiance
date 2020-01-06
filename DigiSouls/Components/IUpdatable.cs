using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiSouls.Components

{
    public interface IUpdatable
    {
        void Update(Input input, GameTime time);
    }
}
