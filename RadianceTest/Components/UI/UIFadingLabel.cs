using Radiance.Components.UI;
using Radiance.Coroutines;

using Microsoft.Xna.Framework;
using Radiance.Events;

namespace RadianceTest.Components.UI
{
    public class UIFadingLabel : UILabel
    {
        public float FadeTime { get; set; }

        public void Fade()
        {
            Color from = this.Color;
            Color to = from;
            to.A = 0;
            this.StartCoroutine(Animation.LerpColorProperty(this, "Color", from, to, this.FadeTime));
        }

        public void Fade(float fadeTime)
        {
            this.FadeTime = fadeTime;
            this.Fade();
        }

        public void FadeAfterDelay(float delay)
        {
            Color from = this.Color;
            Color to = from;
            to.A = 0;
            this.StartCoroutine(Coroutine.WaitForSeconds(delay)).Then(c => c.StartCoroutine(Animation.LerpColorProperty(this, "Color", from, to, this.FadeTime)));
        }

        public void FadeAfterDelay(float delay, float fadeTime)
        {
            this.FadeTime = fadeTime;
            this.FadeAfterDelay(delay);
        }

        public override void OnUIMouseDown(MouseEventArgs e)
        {
            this.FadeAfterDelay(2f);

            base.OnUIMouseDown(e);
        }
    }
}
