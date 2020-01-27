using System.Linq;
using Microsoft.Xna.Framework;

using Radiance.Graphics;
using Radiance.Components;

namespace Radiance.Scenes
{
    public class Scene : Component, IUpdatable, IRenderable
    {
        public string Name { get; private set; }

        public Scene(string name) : base()
        {
            this.Name = name;
        }

        public void Draw(RenderContext g)
        {
            g.Begin();
            foreach (IRenderable child in this.GetAllChildren().Where(c => c.Active && c is IRenderable))
            {
                child.Draw(g);
            }
            g.End();
        }

        public void Update(Input input)
        {
            foreach (IUpdatable child in this.GetAllChildren().Where(c => c.Active && c is IUpdatable))
            {
                child.Update(input);
            }
        }
    }
}
