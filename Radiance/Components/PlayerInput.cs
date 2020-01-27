using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Radiance.Config;
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

        public void Update(Input input)
        {
            bool left = input.IsKeyDown(UserConfig.GetConfig<KeyConfigEntry>(ConfigCategory.Controls, "Left").Value);
            bool right = input.IsKeyDown(UserConfig.GetConfig<KeyConfigEntry>(ConfigCategory.Controls, "Right").Value);
            bool up = input.IsKeyDown(UserConfig.GetConfig<KeyConfigEntry>(ConfigCategory.Controls, "Up").Value);
            bool down = input.IsKeyDown(UserConfig.GetConfig<KeyConfigEntry>(ConfigCategory.Controls, "Down").Value);

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
