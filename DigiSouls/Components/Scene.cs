using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DigiSouls.Components

{
    public class Scene : Component, IUpdatable, IRenderable
    {
        public void Draw(SpriteBatch sb, GameTime time)
        {
            sb.Begin();
            foreach (IRenderable child in this.children.Where(c => c is IRenderable))
            {
                child.Draw(sb, time);
            }
            sb.End();
        }

        public void Update(GameTime time)
        {
            foreach (IUpdatable child in this.children.Where(c => c is IUpdatable))
            {
                child.Update(time);
            }
        }
    }
}
