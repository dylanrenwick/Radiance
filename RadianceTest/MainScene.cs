using Radiance.Scenes;

using RadianceTest.Components;

namespace RadianceTest
{
    public static partial class SceneBuilder
    {
        public static Scene MainScene()
        {
            Scene newScene = new Scene("MainScene");

            var map = new CityMap(100, 100);

            newScene.AddComponent(map);

            return newScene;
        }
    }
}
