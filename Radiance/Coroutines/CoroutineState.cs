using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiance.Coroutines
{
    public class CoroutineState : Tuple<CoroutineStatus, object>
    {
        public CoroutineState(CoroutineStatus item1, object item2) : base(item1, item2) { }

        public static CoroutineState Wait(int milliseconds)
        {
            return CoroutineState.Wait(milliseconds / 1000f);
        }
        public static CoroutineState Wait(float seconds)
        {
            return new CoroutineState(CoroutineStatus.Delay, seconds);
        }

        public static CoroutineState Halt()
        {
            return new CoroutineState(CoroutineStatus.Halt, null);
        }

        public static CoroutineState Tick()
        {
            return new CoroutineState(CoroutineStatus.Tick, null);
        }
    }

    public enum CoroutineStatus
    {
        Tick, // Done for this update loop, resume next tick
        Halt, // Done, terminate
        Delay, // Waiting for some amount of time
    }
}
