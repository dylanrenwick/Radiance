using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

using DigiSouls.Components;
using DigiSouls.Serialization;

namespace DigiSouls.Tile
{
    public class Tilemap : Component
    {
        [SerializedField]
        public Texture2D SpriteAtlas { get; set; }

        [SerializedField]
        public int[,] Map { get; set; }


    }
}
