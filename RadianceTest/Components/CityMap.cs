using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Radiance.Components;
using Radiance.Graphics;

namespace RadianceTest.Components
{
    public class CityMap : Component, IRenderable
    {
        private Tile[,] map;

        public int Width => this.map.GetLength(1);
        public int Height => this.map.GetLength(0);

        public CityMap(int width, int height, Component parent = null) : base(parent)
        {
            this.map = new Tile[height, width];
        }

        public void Draw(RenderContext g)
        {
            Texture2D tex = new Texture2D(g.GraphicsDevice, this.Width, this.Height, false, SurfaceFormat.Color);

            var texData = new Color[this.Height * this.Width];
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    texData[y * this.Height + x] = this.GetTileColor(this.map[y, x]);
                }
            }

            tex.SetData(texData);

            g.DrawTexture(tex, this.Transform.PointPosition, Color.White);
        }

        private Color GetTileColor(Tile tile)
        {
            switch (tile)
            {
                case Tile.Road:
                    return Color.Gray;
                default:
                    return Color.LimeGreen;
            }
        }
    }

    public enum Tile
    {
        Empty = 0,
        Road,
    }
}
