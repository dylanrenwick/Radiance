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
        private Tuple<string, OriginType>[] textures;

        private int itemCount => this.scenes.Count + this.textures.Length;
        private int progress = 0;
        private bool done = false;
        private string statusString;

        private Scene nextScene;

        public override void Start()
        {
            this.scenes = new Dictionary<string, Func<Scene>>
            {
                { "Main Menu", () => this.LoadScene(() => SceneBuilder.MainMenu(new Point(50, 300), new Point(150, 50), 20), true) },
                { "Main Scene", () => this.LoadScene(() => SceneBuilder.MainScene()) }
            };
            this.textures = new Tuple<string, OriginType>[]
            {
                new Tuple<string, OriginType>("playerShip1_blue", OriginType.Center)
            };

            this.LoadBar.MaxValue = this.itemCount;

            Thread loadThread = new Thread(new ThreadStart(this.LoadContent));
            loadThread.IsBackground = true;
            loadThread.Start();
            base.Start();
        }

        public void Update(Input input, GameTime time)
        {
            if (this.done) SceneManager.SetActiveScene(this.nextScene);

            this.StatusLabel.Text = this.statusString;
            float percentage = (float)this.progress / this.itemCount;
            this.LoadBar.NormalizedValue = percentage;
            this.PercentLabel.Text = $"{Math.Round(percentage * 100)}%";
        }

        private void LoadContent()
        {
            foreach (Tuple<string, OriginType> tex in this.textures)
            {
                this.statusString = "Loading Asset: " + tex.Item1;
                DigiSouls.Assets.Assets.LoadTexture2D(tex.Item1, tex.Item2);
                this.progress += 1;
            }

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
