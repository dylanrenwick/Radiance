using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Radiance.Graphics;

namespace Radiance.Scenes
{
    public static class SceneManager
    {
        public static Input Input { get; set; }

        public static Scene ActiveScene { get; private set; }

        private static List<Scene> scenes = new List<Scene>();

        public static void Draw(RenderContext g)
        {
            SceneManager.ActiveScene.Draw(g);
        }

        public static void Update(Input input)
        {
            SceneManager.ActiveScene.Update(input);
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

        public static void SetActiveScene(string name)
        {
            Scene foundScene = SceneManager.scenes.Where(s => s.Name == name).FirstOrDefault();
            if (foundScene != null) SceneManager.SetActiveScene(foundScene);
        }
    }
}
