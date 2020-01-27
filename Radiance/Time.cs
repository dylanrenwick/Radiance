using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Radiance
{
    public static class Time
    {
        public static long Runtime { get; private set; }
        public static float DeltaTime { get; private set; }

        public static void Update(GameTime time)
        {
            Time.Runtime += (long)time.ElapsedGameTime.TotalSeconds;
            Time.DeltaTime = (float)time.ElapsedGameTime.TotalSeconds;
        }
    }
}
