﻿using Radiance.Scenes;

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
                FadeTime = 1f
            };
            zoomIndicator.RectTransform.Rect = new Rectangle(1180, 0, 100, 100);
            map.ZoomIndicator = zoomIndicator;

            newScene.AddComponent(map);
            newScene.AddComponent(zoomIndicator);

            return newScene;
        }
    }
}
