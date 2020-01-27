using System;
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

        private List<Action<Component>> after;

        public bool IsComplete { get; private set; }

        public Coroutine(Component parent, IEnumerator<CoroutineState> coroutine)
        {
            this.parent = parent;
            this.coroutine = coroutine;
            this.after = new List<Action<Component>>();
        }

        public void Run()
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
                        remainingTime -= Time.DeltaTime;
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

            if (this.IsComplete)
            {
                foreach (Action<Component> after in this.after)
                {
                    after(this.parent);
                }
            }
        }

        public Coroutine Then(Action<Component> pred)
        {
            this.after.Add(pred);
            return this;
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

        public static IEnumerator<CoroutineState> WaitForSeconds(float seconds)
        {
            yield return CoroutineState.Wait(seconds);
            yield return CoroutineState.Halt();
        }
    }
}
