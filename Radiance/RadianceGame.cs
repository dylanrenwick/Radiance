using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Radiance.Config;
using Radiance.Scenes;
using Radiance.Graphics;

namespace Radiance
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class RadianceGame : Game
    {
        public static RadianceGame Instance { get; private set; }

        private GraphicsDeviceManager graphics;
        private RenderContext renderContext;

        private Input input;
        
        public RadianceGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
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
            SceneManager.SetActiveScene(SceneBuilder.LoadScreen());
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

            this.input.Update(gameTime);

            SceneManager.Update(this.input, gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            SceneManager.Draw(this.renderContext, gameTime);

            base.Draw(gameTime);
        }
    }
}
