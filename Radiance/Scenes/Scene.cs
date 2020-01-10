﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Draw(RenderContext g, GameTime time)
        {
            g.Begin();
            foreach (IRenderable child in this.Children.Where(c => c.Active && c is IRenderable))
            {
                child.Draw(g, time);
            }
            g.End();
        }

        public void Update(Input input, GameTime time)
        {
            foreach (IUpdatable child in this.Children.Where(c => c.Active && c is IUpdatable))
            {
                child.Update(input, time);
            }
        }
    }
}
