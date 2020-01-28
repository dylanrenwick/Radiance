using System;
using System.Reflection;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Radiance.Util;

namespace Radiance.Coroutines
{
    public static class Animation
    {
        public static IEnumerator<CoroutineState> EaseIntProperty(Func<float, float, float, float> easingFunction, object target, string propertyName, int from, int to, float lerpTime)
        {
            PropertyInfo property = target.GetType().GetProperty(propertyName);
            if (property == null) throw new Exception($"Could not find property {propertyName} on type {target.GetType().AssemblyQualifiedName}");
            if (property.PropertyType != typeof(int)) throw new Exception($"Property {propertyName} on type {target.GetType().AssemblyQualifiedName} is not of type 'int'");

            float elapsedTime = 0;
            while (elapsedTime < lerpTime)
            {
                float t = elapsedTime / lerpTime;

                int lerpedValue = (int)Math.Round(easingFunction(from, to, t));

                property.SetValue(target, lerpedValue);

                elapsedTime += Time.DeltaTime;

                yield return CoroutineState.Tick();
            }
        }

        public static IEnumerator<CoroutineState> EaseFloatProperty(Func<float, float, float, float> easingFunction, object target, string propertyName, float from, float to, float lerpTime)
        {
            PropertyInfo property = target.GetType().GetProperty(propertyName);
            if (property == null) throw new Exception($"Could not find property {propertyName} on type {target.GetType().AssemblyQualifiedName}");
            if (property.PropertyType != typeof(float)) throw new Exception($"Property {propertyName} on type {target.GetType().AssemblyQualifiedName} is not of type 'float'");

            float elapsedTime = 0;
            while (elapsedTime < lerpTime)
            {
                float t = elapsedTime / lerpTime;

                float lerpedValue = easingFunction(from, to, t);

                property.SetValue(target, lerpedValue);

                elapsedTime += Time.DeltaTime;

                yield return CoroutineState.Tick();
            }
        }

        public static IEnumerator<CoroutineState> EaseColorProperty(Func<float, float, float, float> easingFunction, object target, string propertyName, Color from, Color to, float lerpTime)
        {
            PropertyInfo property = target.GetType().GetProperty(propertyName);
            if (property == null) throw new Exception($"Could not find property {propertyName} on type {target.GetType().AssemblyQualifiedName}");
            if (property.PropertyType != typeof(Color)) throw new Exception($"Property {propertyName} on type {target.GetType().AssemblyQualifiedName} is not of type 'Color'");

            float elapsedTime = 0;
            while (elapsedTime < lerpTime)
            {
                float t = elapsedTime / lerpTime;

                Color lerpedValue = new Color()
                {
                    A = (byte)easingFunction(from.A, to.A, t),
                    R = (byte)easingFunction(from.R, to.R, t),
                    G = (byte)easingFunction(from.G, to.G, t),
                    B = (byte)easingFunction(from.B, to.B, t),
                };

                property.SetValue(target, lerpedValue);

                elapsedTime += Time.DeltaTime;

                yield return CoroutineState.Tick();
            }
        }
    }
}
