using Microsoft.Xna.Framework;

using Radiance.Scenes;
using Radiance.Components.UI;

namespace RadianceTest
{
    public static partial class SceneBuilder
    {
        public static Scene MainMenu(Point location, Point buttonSize, int buttonPadding)
        {
            Scene mainMenu = new Scene("MainMenu");

            Point buttonPos = location;

            UILabel title = new UILabel();
            title.Text = "Radiance";
            title.FontSize = 72;
            title.Color = Color.White;
            title.RectTransform.Rect = new Rectangle(50, 50, 1000, 150);

            UIButton playButton = new UIButton();
            playButton.Color = new Color(0f, 0f, 0f, 0.3f);
            playButton.TextColor = Color.White;
            playButton.Text = "Play";
            playButton.RectTransform.Size = new Vector2(buttonSize.X, buttonSize.Y);
            playButton.Transform.LocalPosition = new Vector3(buttonPos.X, buttonPos.Y, 0);
            buttonPos.Y += buttonSize.Y + buttonPadding;

            playButton.OnClick += _ => SceneManager.SetActiveScene("MainScene");

            UIPanel optOverlay = new UIPanel();
            optOverlay.Color = new Color(0f, 0f, 0f, 0.3f);
            optOverlay.RectTransform.Rect = new Rectangle(0, 0, 1280, 720);
            optOverlay.Active = false;

            UIButton optButton = new UIButton();
            optButton.Color = new Color(0f, 0f, 0f, 0.3f);
            optButton.TextColor = Color.White;
            optButton.Text = "Settings";
            optButton.RectTransform.Size = new Vector2(buttonSize.X, buttonSize.Y);
            optButton.Transform.LocalPosition = new Vector3(buttonPos.X, buttonPos.Y, 0);
            buttonPos.Y += buttonSize.Y + buttonPadding;

            optButton.OnClick += _ => optOverlay.Active = !optOverlay.Active;

            UIButton quitButton = new UIButton();
            quitButton.Color = new Color(0f, 0f, 0f, 0.3f);
            quitButton.TextColor = Color.White;
            quitButton.Text = "Quit";
            quitButton.RectTransform.Size = new Vector2(buttonSize.X, buttonSize.Y);
            quitButton.Transform.LocalPosition = new Vector3(buttonPos.X, buttonPos.Y, 0);
            buttonPos.Y += buttonSize.Y + buttonPadding;

            quitButton.OnClick += _ => Game1.Instance.Exit();

            mainMenu.AddComponent(title);
            mainMenu.AddComponent(playButton);
            mainMenu.AddComponent(optOverlay);
            mainMenu.AddComponent(optButton);
            mainMenu.AddComponent(quitButton);

            return mainMenu;
        }
    }
}
