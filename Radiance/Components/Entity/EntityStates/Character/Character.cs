using Microsoft.Xna.Framework;

using Radiance.Assets;
using Radiance.Graphics;
using Radiance.Components;
using Radiance.Components.Entity.Character;

namespace Radiance.Components.Entity.EntityStates.Character
{
    public class Character : Entity, IRenderable
    {
        public Texture2D Sprite { get; set; }
        public Color Color { get; set; }

        private CharacterBody characterBody;

        public Character() : base()
        {
            this.characterBody = new CharacterBody();
            this.AddComponent(characterBody);
            this.stateMachine.MainState = new CharacterIdleState(this.characterBody);
            this.Color = Color.White;
        }

        public void Draw(RenderContext g, GameTime time)
        {
            g.DrawTexture(Sprite, this.Transform.PointPosition, this.Color, this.Transform.Rotation, this.Sprite.Origin);
        }
    }
}
