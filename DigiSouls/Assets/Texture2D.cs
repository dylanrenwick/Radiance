using MG_Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

namespace DigiSouls.Assets
{
    public class Texture2D : Asset
    {
        private MG_Texture2D inner;

        public int Width => inner.Width;
        public int Height => inner.Height;

        public Texture2D(string name, MG_Texture2D inner) : base(name)
        {
            this.inner = inner;
        }

        public static Asset Deserialize(string name) => Assets.LoadTexture2D(name);

        public static implicit operator MG_Texture2D(Texture2D tex) => tex.inner;
    }
}
