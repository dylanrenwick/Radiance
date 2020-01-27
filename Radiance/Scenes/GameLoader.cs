using System;
using System.Threading;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Radiance.Assets;
using Radiance.Components;
using Radiance.Components.UI;

namespace Radiance.Scenes
{
    public class GameLoader : Component, IUpdatable
    {
        public UISlider LoadBar { get; set; }
        public UILabel StatusLabel { get; set; }
        public UILabel PercentLabel { get; set; }

        private int progress = 0;
        private bool done = false;
        private string statusString;

        private string nextScene;

        private LoadInformation loadInfo;

        public GameLoader(LoadInformation loadInfo, string nextScene, Component parent = null) : base(parent)
        {
            this.loadInfo = loadInfo;
            this.nextScene = nextScene;
        }

        public override void Start()
        {
            this.LoadBar.MaxValue = this.loadInfo.ItemCount;

            Thread loadThread = new Thread(new ThreadStart(this.LoadContent));
            loadThread.IsBackground = true;
            loadThread.Start();
            base.Start();
        }

        public void Update(Input input)
        {
            if (this.done) SceneManager.SetActiveScene(this.nextScene);

            this.StatusLabel.Text = this.statusString;
            float percentage = (float)this.progress / this.loadInfo.ItemCount;
            this.LoadBar.NormalizedValue = percentage;
            this.PercentLabel.Text = $"{Math.Round(percentage * 100)}%";
        }

        private void LoadContent()
        {
            foreach (Tuple<string, OriginType> tex in this.loadInfo.Textures)
            {
                this.statusString = "Loading Asset: " + tex.Item1;
                Radiance.Assets.AssetManager.LoadTexture2D(tex.Item1, tex.Item2);
                this.progress += 1;
            }

            foreach (KeyValuePair<string, Func<Scene>> kvp in this.loadInfo.Scenes)
            {
                this.statusString = "Loading Scene: " + kvp.Key;
                SceneManager.AddScene(kvp.Value());
                this.progress += 1;
            }

            this.done = true;
        }

        public struct LoadInformation
        {
            public Dictionary<string, Func<Scene>> Scenes;

            public List<Tuple<string, OriginType>> Textures;
            public List<string> Fonts;

            public int ItemCount => this.Scenes.Count + this.Textures.Count + this.Fonts.Count;
        }
    }
}
