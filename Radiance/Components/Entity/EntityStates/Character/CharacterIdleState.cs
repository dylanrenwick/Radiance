using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radiance.Components.Entity.Character;
using Microsoft.Xna.Framework;

namespace Radiance.Components.Entity.EntityStates.Character
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
            if (!this.characterBody.MoveInputs.HasValue && !this.characterBody.AimInputs.HasValue) return;

            if (this.characterBody.MoveInputs.HasValue)
            {
                Vector2 moveInputs = this.characterBody.MoveInputs.Value;
                this.parentEntity.Transform.LocalPosition += new Vector3(moveInputs, 0) * this.characterBody.Speed;
                if (!this.characterBody.AimInputs.HasValue) HandleAim(moveInputs);
            }

            if (this.characterBody.AimInputs.HasValue) HandleAim(this.characterBody.AimInputs.Value);
        }

        private void HandleAim(Vector2 aimInputs)
        {
            float targetRotation = (float)Math.Atan2(aimInputs.Y, aimInputs.X) * (180 / (float)Math.PI);
            float diff = targetRotation - this.parentEntity.Transform.LocalRotation + 90;
            if (Math.Abs(diff) > 180) diff = -Math.Sign(diff) * (360 - Math.Abs(diff));
            if (Math.Abs(diff) > this.characterBody.TurnSpeed) diff = Math.Sign(diff) * this.characterBody.TurnSpeed;
            this.parentEntity.Transform.LocalRotation += diff;
        }
    }
}
