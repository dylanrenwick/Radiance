using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

using MG_Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

namespace DigiSouls.Assets
{
    public static class Assets
    {
        public static ContentManager Content;

        private static Dictionary<string, Texture2D> texture2Ds = new Dictionary<string, Texture2D>();
        private static Dictionary<string, Font> fonts = new Dictionary<string, Font>();

        public static Texture2D LoadTexture2D(string assetPath, OriginType originType = OriginType.Center)
        {
            if (!texture2Ds.ContainsKey(assetPath)) texture2Ds.Add(assetPath, new Texture2D(assetPath, Load<MG_Texture2D>(assetPath), originType));
            return texture2Ds[assetPath];            
        }

        public static Font LoadFont(string assetPath)
        {
            if (!fonts.ContainsKey(assetPath)) fonts.Add(assetPath, new Font(assetPath, Load<SpriteFont>(assetPath)));
            return fonts[assetPath];
        }

        private static T Load<T>(string assetPath)
        {
            if (Content == null) throw new Exception("Attempted to load content before Load Content!");
            return Content.Load<T>(assetPath);
        }
    }

    public enum OriginType
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
        Center
    }
}
