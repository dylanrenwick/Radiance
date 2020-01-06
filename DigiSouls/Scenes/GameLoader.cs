using System;
using System.Threading;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using DigiSouls.Assets;
using DigiSouls.Components;
using DigiSouls.Components.UI;

namespace DigiSouls.Scenes
{
    public class GameLoader : Component, IUpdatable
    {
        public UISlider LoadBar { get; set; }
        public UILabel StatusLabel { get; set; }
        public UILabel PercentLabel { get; set; }

        private Dictionary<string, Func<Scene>> scenes;

        private int itemCount => scenes.Count;
        private int progress = 0;
        private bool done = false;
        private string statusString;

        private Scene nextScene;

        public override void Start()
        {
            this.scenes = new Dictionary<string, Func<Scene>>
            {
                { "Main Menu",
                    () => this.LoadScene(() => SceneBuilder.MainMenu(new Point(50, 300), new Point(150, 50), 20), true)
                }
            };

            this.LoadBar.MaxValue = this.itemCount;

            Thread loadThread = new Thread(new ThreadStart(this.LoadContent));
            loadThread.IsBackground = true;
            loadThread.Start();
            base.Start();
        }

        public void Update(GameTime time)
        {
            if (this.done) SceneManager.SetActiveScene(this.nextScene);

            this.StatusLabel.Text = this.statusString;
            float percentage = this.progress / this.itemCount;
            this.LoadBar.NormalizedValue = percentage;
            this.PercentLabel.Text = $"{Math.Round(percentage * 100)}%";
        }

        private void LoadContent()
        {
            foreach (KeyValuePair<string, Func<Scene>> kvp in this.scenes)
            {
                this.statusString = "Loading Scene: " + kvp.Key;
                SceneManager.AddScene(kvp.Value());
                this.progress += 1;
            }

            this.done = true;
        }

        private Scene LoadScene(Func<Scene> sceneBuilder, bool makePrimary = false)
        {
            Scene newScene = sceneBuilder();
            if (makePrimary) this.nextScene = newScene;
            return newScene;
        }
    }
}
