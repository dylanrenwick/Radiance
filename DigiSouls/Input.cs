using DigiSouls.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public bool MouseButtonsSwapped { get; private set; }

        private MouseState previousMouseState;

#if WINDOWS
        [DllImport("User32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr GetSystemMetrics(IntPtr hnewview);
#endif

        public Input()
        {
#if WINDOWS
            this.MouseButtonsSwapped = GetSystemMetrics(new IntPtr(23)).ToInt32() != 0;
#elif LINUX
            this.MouseButtonsSwapped = false;
#endif
        }

        public void Update(GameTime gameTime)
        {
            this.UpdateMouse();
        }

        private void UpdateMouse()
        {
            MouseState mouse = Mouse.GetState();
            if (mouse.Equals(this.previousMouseState)) return;

            if (this.IsLeftButtonDown(mouse))
            {
                if (!this.IsLeftButtonDown(this.previousMouseState))
                {
                    this.OnMouseButtonDown?.Invoke(new MouseEventArgs(mouse, this.previousMouseState));
                }
            }
            else if (this.IsLeftButtonDown(this.previousMouseState))
            {
                this.OnMouseButtonUp?.Invoke(new MouseEventArgs(mouse, this.previousMouseState));
            }

            if (mouse.Position != this.previousMouseState.Position)
            {
                this.OnMouseMove?.Invoke(new MouseEventArgs(mouse, this.previousMouseState));
            }

            this.previousMouseState = mouse;
        }

        private bool IsLeftButtonDown(MouseState m)
        {
            if (this.MouseButtonsSwapped) return m.RightButton == ButtonState.Pressed;
            return m.LeftButton == ButtonState.Pressed;
        }
    }
}
