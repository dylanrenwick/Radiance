using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Radiance.Components.Entity.EntityStates;
using Microsoft.Xna.Framework;

namespace Radiance.Components.Entity
{
    public class Entity : Component, IUpdatable
    {
        protected EntityStateMachine stateMachine;

        public Entity() : base()
        {
            this.stateMachine = new EntityStateMachine();
            this.AddComponent(this.stateMachine);
        }
        public Entity(EntityState mainState) : base()
        {
            this.AddComponent(new EntityStateMachine(mainState));
        }

        public void Update(Input input)
        {
            foreach (IUpdatable child in this.Children.Where(c => c is IUpdatable))
            {
                child.Update(input);
            }
        }
    }
}
