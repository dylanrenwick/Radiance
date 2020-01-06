using Microsoft.Xna.Framework;

namespace DigiSouls.Components.Entity.EntityStates
{
    public abstract class EntityState
    {
        private EntityStateMachine parentMachine;
        protected Entity parentEntity => this.parentMachine.Entity;

        public abstract void Update(GameTime gameTime);
    }
}
