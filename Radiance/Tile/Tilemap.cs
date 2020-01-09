using Microsoft.Xna.Framework.Graphics;

using Radiance.Components;

namespace Radiance.Tile
{
    public class Tilemap : Component
    {
        public Texture2D SpriteAtlas { get; set; }
        public int[,] Map { get; set; }


    }
}
