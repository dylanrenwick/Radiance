using Radiance.Scenes;

using RadianceTest.Components;
using RadianceTest.Components.UI;

using Microsoft.Xna.Framework;

namespace RadianceTest
{
    public static partial class SceneBuilder
    {
        public static Scene MainScene()
        {
            Scene newScene = new Scene("MainScene");

            var map = new CityMap(100, 100);

            var zoomIndicator = new UIFadingLabel()
            {
                Text = "1x",
                Color = Color.White,
                FontSize = 48,
                FadeTime = 2f
            };
            zoomIndicator.RectTransform.Rect = new Rectangle(100, 100, 100, 100);

            newScene.AddComponent(map);
            newScene.AddComponent(zoomIndicator);

            return newScene;
        }
    }
}
