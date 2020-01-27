using System;
using System.Reflection;
using System.Collections.Generic;

using Radiance.Components;

using Microsoft.Xna.Framework;

namespace Radiance.Coroutines
{
    public static class Animation
    {
        public static IEnumerator<CoroutineState> LerpIntProperty(object target, string propertyName, int from, int to, float lerpTime)
        {
            PropertyInfo property = target.GetType().GetProperty(propertyName);
            if (property == null) throw new Exception($"Could not find property {propertyName} on type {target.GetType().AssemblyQualifiedName}");
            if (property.PropertyType != typeof(int)) throw new Exception($"Property {propertyName} on type {target.GetType().AssemblyQualifiedName} is not of type 'int'");

            float elapsedTime = 0;
            while (elapsedTime < lerpTime)
            {
                int diff = to - from;
                float t = elapsedTime / lerpTime;

                int lerpedValue = from + (int)Math.Floor(diff * t);

                property.SetValue(target, lerpedValue);

                elapsedTime += Time.DeltaTime;

                yield return CoroutineState.Tick();
            }
        }

        public static IEnumerator<CoroutineState> LerpFloatProperty(object target, string propertyName, float from, float to, float lerpTime)
        {
            PropertyInfo property = target.GetType().GetProperty(propertyName);
            if (property == null) throw new Exception($"Could not find property {propertyName} on type {target.GetType().AssemblyQualifiedName}");
            if (property.PropertyType != typeof(float)) throw new Exception($"Property {propertyName} on type {target.GetType().AssemblyQualifiedName} is not of type 'float'");

            float elapsedTime = 0;
            while (elapsedTime < lerpTime)
            {
                float diff = to - from;
                float t = elapsedTime / lerpTime;

                float lerpedValue = from + (diff * t);

                property.SetValue(target, lerpedValue);

                elapsedTime += Time.DeltaTime;

                yield return CoroutineState.Tick();
            }
        }

        public static IEnumerator<CoroutineState> LerpColorProperty(object target, string propertyName, Color from, Color to, float lerpTime)
        {
            PropertyInfo property = target.GetType().GetProperty(propertyName);
            if (property == null) throw new Exception($"Could not find property {propertyName} on type {target.GetType().AssemblyQualifiedName}");
            if (property.PropertyType != typeof(Color)) throw new Exception($"Property {propertyName} on type {target.GetType().AssemblyQualifiedName} is not of type 'Color'");

            float elapsedTime = 0;
            while (elapsedTime < lerpTime)
            {
                int diffA = to.A - from.A;
                int diffR = to.R - from.R;
                int diffG = to.G - from.G;
                int diffB = to.B - from.B;
                float t = elapsedTime / lerpTime;

                Color lerpedValue = new Color()
                {
                    A = (byte)(from.A + Math.Floor(diffA * t)),
                    R = (byte)(from.R + Math.Floor(diffR * t)),
                    G = (byte)(from.G + Math.Floor(diffG * t)),
                    B = (byte)(from.B + Math.Floor(diffB * t)),
                };

                property.SetValue(target, lerpedValue);

                elapsedTime += Time.DeltaTime;

                yield return CoroutineState.Tick();
            }
        }
    }
}
