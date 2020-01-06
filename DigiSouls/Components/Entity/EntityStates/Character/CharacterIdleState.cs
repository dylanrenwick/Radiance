using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiSouls.Components.Entity.Character;
using Microsoft.Xna.Framework;

namespace DigiSouls.Components.Entity.EntityStates.Character
{
    public class CharacterIdleState : EntityState
    {
        private CharacterBody characterBody;

        public CharacterIdleState(CharacterBody charBody)
        {
            this.characterBody = charBody;
        }

        public CharacterIdleState() : base() { }

        public override void Update(GameTime gameTime)
        {
            this.parentEntity.Transform.LocalPosition += new Vector3(this.characterBody.MoveInputs, 0);
        }
    }
}
