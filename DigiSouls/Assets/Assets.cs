using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiSouls.Assets
{
    public static class Assets
    {
        public static ContentManager Content;

        private static Dictionary<string, Texture2D> texture2Ds = new Dictionary<string, Texture2D>();

        public static Texture2D LoadTexture2D(string assetPath)
        {
            if (!texture2Ds.ContainsKey(assetPath)) texture2Ds.Add(assetPath, Load<Texture2D>(assetPath));
            return texture2Ds[assetPath];            
        }

        private static T Load<T>(string assetPath)
        {
            if (Content == null) throw new Exception("Attempted to load content before Load Content!");
            return Content.Load<T>(assetPath);
        }
    }
}
