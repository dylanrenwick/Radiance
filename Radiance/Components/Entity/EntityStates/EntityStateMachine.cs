using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Radiance.Components.Entity.EntityStates
{
    public class EntityStateMachine : Component, IUpdatable
    {
        public Entity Entity => (Entity)this.Parent;

        public EntityState MainState { get; set; }

        private EntityState _currentState;
        private EntityState currentState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                _currentState.ParentMachine = this;
            }
        }

        public EntityStateMachine() : base() { }
        public EntityStateMachine(EntityState mainState) : base()
        {
            this.MainState = mainState;
        }

        public void Update(Input input)
        {
            if (this.currentState == null)
            {
                if (this.MainState == null) return;
                this.currentState = this.MainState;
            }
            this.currentState.Update();
        }
    }
}
