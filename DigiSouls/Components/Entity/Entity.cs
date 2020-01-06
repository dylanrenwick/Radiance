using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DigiSouls.Components.Entity.EntityStates;
using Microsoft.Xna.Framework;

namespace DigiSouls.Components.Entity
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

        public void Update(Input input, GameTime time)
        {
            foreach (IUpdatable child in this.children.Where(c => c is IUpdatable))
            {
                child.Update(input, time);
            }
        }
    }
}
