using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using DigiSouls.Graphics;
using DigiSouls.Component;
using DigiSouls.Component.UI;

namespace DigiSouls
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class DigiSoulsGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Scene scene;
        
        public DigiSoulsGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            this.IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Primitives.Init(spriteBatch);
            DigiSouls.Assets.Assets.Content = this.Content;

            // TODO: use this.Content to load your game content here

            this.scene = new Scene();
            var panel = new UIPanel();
            panel.RectTransform.Rect = new Rectangle(10, 10, 50, 120);
            panel.Color = new Color(0f, 0f, 0f, 0.6f);
            this.scene.AddComponent(panel);

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

            this.scene.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.scene.Draw(this.spriteBatch, gameTime);

            base.Draw(gameTime);
        }
    }
}
