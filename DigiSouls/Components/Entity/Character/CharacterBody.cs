using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DigiSouls.Components.Entity.Character
{
    public class CharacterBody : Component
    {
        public Vector2? MoveInputs { get; set; }
        public Vector2? AimInputs { get; set; }

        public float Speed { get; set; }
        public float TurnSpeed { get; set; }
    }
}
