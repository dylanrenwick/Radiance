using Microsoft.Xna.Framework;

using DigiSouls.Components;
using DigiSouls.Components.Entity.Character;
using DigiSouls.Components.Entity.EntityStates.Character;

namespace DigiSouls.Scenes
{
    public static partial class SceneBuilder
    {
        public static Scene MainScene()
        {
            Scene newScene = new Scene("MainScene");

            Character player = new Character();
            CharacterBody cb = player.GetComponent<CharacterBody>();
            cb.Speed = 5f;
            cb.TurnSpeed = 15f;
            player.AddComponent(new PlayerInput(cb));
            player.Transform.LocalPosition = new Vector3(100, 100, 0);
            player.Sprite = DigiSouls.Assets.Assets.LoadTexture2D("playerShip1_blue");

            newScene.AddComponent(player);

            return newScene;
        }
    }
}
