using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

using DigiSouls.Graphics;
using DigiSouls.Components;

namespace DigiSouls.Scenes
{
    public class Scene : Component, IUpdatable, IRenderable
    {
        public string Name { get; private set; }

        public Scene(string name) : base()
        {
            this.Name = name;
        }

        public void Draw(RenderContext g, GameTime time)
        {
            g.Begin();
            foreach (IRenderable child in this.children.Where(c => c is IRenderable))
            {
                child.Draw(g, time);
            }
            g.End();
        }

        public void Update(Input input, GameTime time)
        {
            foreach (IUpdatable child in this.children.Where(c => c is IUpdatable))
            {
                child.Update(input, time);
            }
        }
    }
}
