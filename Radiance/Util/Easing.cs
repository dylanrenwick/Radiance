using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiance.Util
{
    public static class Easing
    {
        public static float Lerp(float a, float b, float t)
        {
            return (b - a) * t + a;
        }

        public static float QuadIn(float a, float b, float t)
        {
            return (b - a) * (float)Math.Pow(t, 2) + a;
        }

        public static float QuadOut(float a, float b, float t)
        {
            return -(b - a) * t * (t - 2) + a;
        }

        public static float QuadInOut(float a, float b, float t)
        {
            t *= 2;
            if (t < 1) return (b - a) / 2 * (float)Math.Pow(t, 2) + a;
            t--;
            return -(b - a) / 2 * (t * (t - 2) - 1) + a;
        }

        public static float CubicIn(float a, float b, float t)
        {
            return (b - a) * (float)Math.Pow(t, 3) + a;
        }

        public static float CubicOut(float a, float b, float t)
        {
            return (b - a) * (float)(Math.Pow(--t, 3) + 1) + a;
        }

        public static float CubicInOut(float a, float b, float t)
        {
            t *= 2;
            if (t < 1) return (b - a) / 2 * (float)Math.Pow(t, 3) + a; ;
            t--;
            return (b - a) / 2 * (float)(Math.Pow(--t, 3) + 1) + a;
        }
    }
}
