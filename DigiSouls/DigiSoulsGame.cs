using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using DigiSouls.Scenes;
using DigiSouls.Graphics;
using DigiSouls.Components;
using DigiSouls.Components.UI;

namespace DigiSouls
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class DigiSoulsGame : Game
    {
        public static DigiSoulsGame Instance { get; private set; }

        private GraphicsDeviceManager graphics;
        private RenderContext renderContext;

        private Input input;
        private Scene scene;
        
        public DigiSoulsGame()
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
            DigiSoulsGame.Instance = this;
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

            DigiSouls.Assets.Assets.Content = this.Content;
            renderContext.Font = DigiSouls.Assets.Assets.LoadFont("Alchemist");

            this.input = new Input();

            this.scene = SceneBuilder.MainMenu(new Point(50, 300), new Point(150, 50), 20);

            this.input.OnMouseButtonDown += this.scene.OnMouseDown;
            this.input.OnMouseButtonUp += this.scene.OnMouseUp;
            this.input.OnMouseMove += this.scene.OnMouseMove;

            this.scene.Start();
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

            this.scene.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            this.scene.Draw(this.renderContext, gameTime);

            base.Draw(gameTime);
        }
    }
}
