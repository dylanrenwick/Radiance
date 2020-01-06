using DigiSouls.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiSouls
{
    public class Input
    {
        public delegate void MouseEventHandler(MouseEventArgs args);
        public event MouseEventHandler OnMouseButtonDown;
        public event MouseEventHandler OnMouseButtonUp;
        public event MouseEventHandler OnMouseMove;

        private MouseState previousMouseState;

        public Input()
        {

        }

        public void Update(GameTime gameTime)
        {
            this.UpdateMouse();
        }

        private void UpdateMouse()
        {
            MouseState mouse = Mouse.GetState();
            if (mouse.Equals(this.previousMouseState)) return;

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                if (this.previousMouseState.LeftButton == ButtonState.Released)
                {
                    this.OnMouseButtonDown?.Invoke(new MouseEventArgs(mouse, this.previousMouseState));
                }
            }
            else if (this.previousMouseState.LeftButton == ButtonState.Pressed)
            {
                this.OnMouseButtonUp?.Invoke(new MouseEventArgs(mouse, this.previousMouseState));
            }

            if (mouse.Position != this.previousMouseState.Position)
            {
                this.OnMouseMove?.Invoke(new MouseEventArgs(mouse, this.previousMouseState));
            }

            this.previousMouseState = mouse;
        }
    }
}
