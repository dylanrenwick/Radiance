using Microsoft.Xna.Framework;

namespace Radiance.Components.Entity.EntityStates
{
    public abstract class EntityState
    {
        public EntityStateMachine ParentMachine { get; set; }
        protected Entity parentEntity => this.ParentMachine.Entity;

        public abstract void Update();
    }
}
