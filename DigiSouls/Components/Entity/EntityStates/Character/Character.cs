using DigiSouls.Components.Entity.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiSouls.Components.Entity.EntityStates.Character
{
    public class Character : Entity
    {
        private CharacterBody characterBody;

        public Character()
        {
            this.characterBody = new CharacterBody();
            this.stateMachine = new EntityStateMachine(new CharacterIdleState(this.characterBody));
        }
    }
}
