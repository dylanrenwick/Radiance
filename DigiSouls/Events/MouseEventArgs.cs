using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiSouls.Events
{
    public class MouseEventArgs : EventArgs
    {
        public Point Location { get; private set; }
        public Point MouseDelta { get; private set; }
        public Vector2 LocationVector => new Vector2(this.X, this.Y);

        public int X => this.Location.X;
        public int Y => this.Location.Y;

        public bool LeftButton { get; private set; }
        public bool RightButton { get; private set; }
        public bool MiddleButton { get; private set; }

        public MouseEventArgs(MouseState state, MouseState oldState)
        {
            this.Location = state.Position;
            this.MouseDelta = new Point(state.Position.X - oldState.Position.X, state.Position.Y - oldState.Position.Y);

            this.LeftButton = state.LeftButton == ButtonState.Pressed;
            this.RightButton = state.RightButton == ButtonState.Pressed;
            this.MiddleButton = state.MiddleButton == ButtonState.Pressed;
        }
    }
}
