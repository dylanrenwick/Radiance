using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Radiance.Components;

namespace Radiance.Coroutines
{
    public class Coroutine
    {
        private Component parent;
        private IEnumerator<CoroutineState> coroutine;
        private CoroutineState currentState;

        public bool IsComplete { get; private set; }

        public Coroutine(Component parent, IEnumerator<CoroutineState> coroutine)
        {
            this.parent = parent;
            this.coroutine = coroutine;
        }

        public void Run(GameTime time)
        {
            if (currentState != null)
            {
                switch (this.currentState.Item1)
                {
                    case CoroutineStatus.Halt:
                        this.IsComplete = true;
                        break;
                    case CoroutineStatus.Delay:
                        float remainingTime = (float)this.currentState.Item2;
                        remainingTime -= (float)time.ElapsedGameTime.TotalSeconds;
                        if (remainingTime <= 0) ResumeCoroutine();
                        else this.currentState = new CoroutineState(this.currentState.Item1, remainingTime);
                        break;
                    default:
                        ResumeCoroutine();
                        break;
                }
            }
            else
            {
                this.ResumeCoroutine();
            }
        }

        private void ResumeCoroutine()
        {
            bool completed = !this.coroutine.MoveNext();
            this.currentState = this.coroutine.Current;

            if (completed || this.currentState.Item1 == CoroutineStatus.Halt)
            {
                this.IsComplete = true;
            }
        }
    }
}
