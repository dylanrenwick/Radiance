using Microsoft.Xna.Framework;

using Radiance.Components.UI;

namespace Radiance.Scenes
{
    public static partial class SceneBuilder
    {
        public static Scene LoadScreen()
        {
            Scene loadScreen = new Scene("LoadScreen");

            UISlider loadBar = new UISlider(1, 0, Color.Yellow);
            loadBar.RectTransform.Rect = new Rectangle(50, 600, 1180, 35);
            loadBar.Color = Color.DarkGray;

            UILabel statusLabel = new UILabel();
            statusLabel.FontSize = 24;
            statusLabel.Color = Color.White;
            statusLabel.HorizontalAlign = Graphics.TextHoriAlign.Middle;
            statusLabel.RectTransform.Rect = new Rectangle(0, 550, 1280, 50);

            UILabel percentLabel = new UILabel();
            percentLabel.FontSize = 24;
            percentLabel.Color = Color.White;
            percentLabel.HorizontalAlign = Graphics.TextHoriAlign.Middle;
            percentLabel.RectTransform.Rect = new Rectangle(0, 500, 1280, 50);

            GameLoader loader = new GameLoader();
            loader.LoadBar = loadBar;
            loader.StatusLabel = statusLabel;
            loader.PercentLabel = percentLabel;

            loadScreen.AddComponent(loadBar);
            loadScreen.AddComponent(statusLabel);
            loadScreen.AddComponent(percentLabel);
            loadScreen.AddComponent(loader);

            return loadScreen;
        }
    }
}
