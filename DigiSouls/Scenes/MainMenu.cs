using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using DigiSouls.Components;
using DigiSouls.Components.UI;

namespace DigiSouls.Scenes
{
    public static partial class SceneBuilder
    {
        public static Scene MainMenu(Point location, Point buttonSize, int buttonPadding)
        {
            Scene mainMenu = new Scene();

            Point buttonPos = location;

            UIButton playButton = new UIButton();
            playButton.Color = new Color(0f, 0f, 0f, 0.3f);
            playButton.TextColor = Color.White;
            playButton.Text = "Play";
            playButton.RectTransform.Size = new Vector2(buttonSize.X, buttonSize.Y);
            playButton.Transform.LocalPosition = new Vector3(buttonPos.X, buttonPos.Y, 0);
            buttonPos.Y += buttonSize.Y + buttonPadding;

            UIButton quitButton = new UIButton();
            quitButton.Color = new Color(0f, 0f, 0f, 0.3f);
            quitButton.TextColor = Color.White;
            quitButton.Text = "Quit";
            quitButton.RectTransform.Size = new Vector2(buttonSize.X, buttonSize.Y);
            quitButton.Transform.LocalPosition = new Vector3(buttonPos.X, buttonPos.Y, 0);
            buttonPos.Y += buttonSize.Y + buttonPadding;

            quitButton.OnClick += _ => DigiSoulsGame.Instance.Exit();

            mainMenu.AddComponent(playButton);
            mainMenu.AddComponent(quitButton);

            return mainMenu;
        }
    }
}
