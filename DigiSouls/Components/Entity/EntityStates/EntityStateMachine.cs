using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace DigiSouls.Components.Entity.EntityStates
{
    public class EntityStateMachine : Component, IUpdatable
    {
        public Entity Entity => (Entity)this.Parent;

        private EntityState mainState;
        private EntityState currentState;

        public EntityStateMachine() : base() { }
        public EntityStateMachine(EntityState mainState) : base()
        {
            this.mainState = mainState;
        }

        public void Update(GameTime gameTime)
        {
            if (this.currentState == null) this.currentState = this.mainState;
            this.currentState.Update(gameTime);
        }
    }
}
