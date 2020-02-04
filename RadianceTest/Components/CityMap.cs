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

        private bool isMouseGrabbing;

        public CityMap(int width, int height, Component parent = null) : base(parent)
        {
            this.map = new Tile[height, width];
            this.zoomLevel = 10;
            this.isDirty = true;
            this.map[10, 10] = Tile.Road;
            this.map[62, 118] = Tile.Road;
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

        public override void OnMouseDown(MouseEventArgs e)
        {
            this.isMouseGrabbing = e.RightButton;

            base.OnMouseDown(e);
        }

        public override void OnMouseUp(MouseEventArgs e)
        {
            this.isMouseGrabbing = e.RightButton;

            base.OnMouseUp(e);
        }

        public override void OnMouseMove(MouseEventArgs e)
        {
            if (this.isMouseGrabbing)
            {
                this.Transform.LocalPointPosition += e.MouseDelta;
            }

            base.OnMouseMove(e);
        }

        private void GenerateTexture(RenderContext g)
        {
            this.mapTex = new Texture2D(g.GraphicsDevice, this.Width, this.Height);

            var texData = new Color[this.Height * this.Width];
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    texData[y * this.Width + x] = this.GetTileColor(this.map[y, x]);
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
