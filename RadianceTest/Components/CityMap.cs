using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Radiance.Components;
using Radiance.Events;
using Radiance.Graphics;

using RadianceTest.Components.UI;

namespace RadianceTest.Components
{
    public class CityMap : Component, IRenderable
    {
        private Tile[,] map;

        public int Width => this.map.GetLength(1);
        public int Height => this.map.GetLength(0);

        public UIFadingLabel ZoomIndicator;

        private int zoomLevel;

        private Texture2D mapTex;

        private bool isDirty;

        public CityMap(int width, int height, Component parent = null) : base(parent)
        {
            this.map = new Tile[height, width];
            this.zoomLevel = 1;
            this.isDirty = true;
        }

        public void Draw(RenderContext g)
        {
            if (this.isDirty) this.GenerateTexture(g);
            g.DrawTexture(this.mapTex, this.Transform.PointPosition, Color.White, 0, Point.Zero, new Vector2(this.zoomLevel, this.zoomLevel));
        }

        public override void OnMouseScrollUp(MouseEventArgs e)
        {
            this.zoomLevel++;
            this.ZoomIndicator.Text = $"{this.zoomLevel}x";
            this.ZoomIndicator.Color = Color.White;
            this.ZoomIndicator.FadeAfterDelay(2);

            base.OnMouseScrollUp(e);
        }

        public override void OnMouseScrollDown(MouseEventArgs e)
        {
            this.zoomLevel--;
            this.ZoomIndicator.Text = $"{this.zoomLevel}x";
            this.ZoomIndicator.Color = Color.White;
            this.ZoomIndicator.FadeAfterDelay(2);

            base.OnMouseScrollDown(e);
        }

        private void GenerateTexture(RenderContext g)
        {
            this.mapTex = new Texture2D(g.GraphicsDevice, this.Width, this.Height, false, SurfaceFormat.Color);

            var texData = new Color[this.Height * this.Width];
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    texData[y * this.Height + x] = this.GetTileColor(this.map[y, x]);
                }
            }

            this.mapTex.SetData(texData);

            this.isDirty = false;
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
