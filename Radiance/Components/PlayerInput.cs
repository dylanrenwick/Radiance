using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Radiance.Components.Entity.Character;

namespace Radiance.Components
{
    public class PlayerInput : Component, IUpdatable
    {
        private CharacterBody characterBody;

        public PlayerInput(CharacterBody cb)
        {
            this.characterBody = cb;
        }

        public void Update(Input input, GameTime time)
        {
            bool left = input.IsAnyKeyDown(Keys.Left, Keys.A);
            bool right = input.IsAnyKeyDown(Keys.Right, Keys.D);
            bool up = input.IsAnyKeyDown(Keys.Up, Keys.W);
            bool down = input.IsAnyKeyDown(Keys.Down, Keys.S);

            bool click = input.IsLeftButtonDown();

            if (!left && !right && !up && !down)
            {
                characterBody.MoveInputs = null;
                if (!click)
                {
                    characterBody.AimInputs = null;
                    return;
                }
            }
            else
            {
                Vector2 inputVector = new Vector2();
                inputVector.X = left ? (!right ? -1f : 0f) : (right ? 1f : 0f);
                inputVector.Y = up ? (!down ? -1f : 0f) : (down ? 1f : 0f);
                inputVector.Normalize();

                characterBody.MoveInputs = inputVector;
                if (!click) characterBody.AimInputs = inputVector;
            }

            if (click)
            {
                Point mousePos = input.MousePosition;
                Point diff = mousePos - this.Transform.PointPosition;
                this.characterBody.AimInputs = new Vector2(diff.X, diff.Y);
            }
        }
    }
}
