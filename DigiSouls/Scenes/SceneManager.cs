using System.Collections.Generic;

using Microsoft.Xna.Framework;

using DigiSouls.Graphics;

namespace DigiSouls.Scenes
{
    public static class SceneManager
    {
        public static Input Input { get; set; }

        public static Scene ActiveScene { get; private set; }

        private static List<Scene> scenes = new List<Scene>();

        public static void Draw(RenderContext g, GameTime gameTime)
        {
            SceneManager.ActiveScene.Draw(g, gameTime);
        }

        public static void Update(GameTime gameTime)
        {
            SceneManager.ActiveScene.Update(gameTime);
        }

        public static void AddScene(Scene s)
        {
            SceneManager.scenes.Add(s);
        }

        public static void SetActiveScene(Scene s)
        {
            if (!SceneManager.scenes.Contains(s)) SceneManager.AddScene(s);
            if (SceneManager.ActiveScene != null)
            {
                SceneManager.Input.OnMouseButtonDown -= SceneManager.ActiveScene.OnMouseDown;
                SceneManager.Input.OnMouseButtonUp -= SceneManager.ActiveScene.OnMouseUp;
                SceneManager.Input.OnMouseMove -= SceneManager.ActiveScene.OnMouseMove;

                SceneManager.ActiveScene.Sleep();
            }

            SceneManager.ActiveScene = s;

            SceneManager.Input.OnMouseButtonDown += SceneManager.ActiveScene.OnMouseDown;
            SceneManager.Input.OnMouseButtonUp += SceneManager.ActiveScene.OnMouseUp;
            SceneManager.Input.OnMouseMove += SceneManager.ActiveScene.OnMouseMove;

            SceneManager.ActiveScene.Start();
        }
    }
}
