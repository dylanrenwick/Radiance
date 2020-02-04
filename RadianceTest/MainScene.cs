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

            var map = new CityMap(128, 72);

            var zoomIndicator = new UIFadingLabel()
            {
                Text = "10x",
                Color = Color.White,
                FontSize = 48,
                FadeTime = 1f
            };
            zoomIndicator.RectTransform.Rect = new Rectangle(1150, 0, 100, 100);
            map.ZoomIndicator = zoomIndicator;

            newScene.AddComponent(map);
            newScene.AddComponent(zoomIndicator);

            return newScene;
        }
    }
}
