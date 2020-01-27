using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Radiance.Assets;
using Radiance.Config;
using Radiance.Scenes;
using Radiance.Graphics;
using Radiance.Coroutines;

namespace Radiance
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public abstract class RadianceGame : Game
    {
        public static RadianceGame Instance { get; private set; }

        protected string mainSceneName;

        private GraphicsDeviceManager graphics;
        private RenderContext renderContext;

        private Input input;

        private Dictionary<string, Func<Scene>> scenes;
        private List<Tuple<string, OriginType>> textures;
        private List<string> fonts;

        private List<Coroutine> coroutines;

        public RadianceGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }

        public void LoadScene(string name, Func<Scene> factoryMethod)
        {
            this.scenes[name] = factoryMethod;
        }
        public void LoadScenes(List<Tuple<string, Func<Scene>>> scenes)
        {
            foreach (var scene in scenes)
            {
                this.LoadScene(scene.Item1, scene.Item2);
            }
        }

        public void LoadTexture2D(string path, OriginType originType = OriginType.Center)
        {
            this.textures.Add(new Tuple<string, OriginType>(path, originType));
        }
        public void LoadTexture2Ds(List<Tuple<string, OriginType>> textures)
        {
            this.textures.AddRange(textures);
        }

        public void LoadFont(string path)
        {
            this.fonts.Add(path);
        }
        public void LoadFonts(List<string> paths)
        {
            this.fonts.AddRange(paths);
        }

        public void StartCoroutine(Coroutine coroutine)
        {
            this.coroutines.Add(coroutine);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            RadianceGame.Instance = this;

            this.scenes = new Dictionary<string, Func<Scene>>();
            this.textures = new List<Tuple<string, OriginType>>();
            this.fonts = new List<string>();

            this.coroutines = new List<Coroutine>();

            base.Initialize();
            this.IsMouseVisible = true;

            this.graphics.PreferredBackBufferWidth = 1280;
            this.graphics.PreferredBackBufferHeight = 720;
            this.graphics.ApplyChanges();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            var spriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.renderContext = new RenderContext(spriteBatch);
            renderContext.MainCamera = new Camera();

            UserConfig.LoadConfig();

            Radiance.Assets.AssetManager.Content = this.Content;
            // Load default font
            renderContext.Font = Radiance.Assets.AssetManager.LoadFont("Arial");

            this.input = new Input();
            SceneManager.Input = this.input;
            SceneManager.SetActiveScene(SceneBuilder.LoadScreen(new GameLoader.LoadInformation()
            {
                Scenes = this.scenes,
                Textures = this.textures,
                Fonts = this.fonts
            }, this.mainSceneName));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Time.Update(gameTime);

            this.input.Update();

            SceneManager.Update(this.input);

            foreach (Coroutine coroutine in this.coroutines)
            {
                coroutine.Run();
            }

            this.coroutines = this.coroutines.Where(c => !c.IsComplete).ToList();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            SceneManager.Draw(this.renderContext);

            base.Draw(gameTime);
        }
    }
}
