﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Newtonsoft.Json.Linq;

using DigiSouls.Serialization;

namespace DigiSouls.Component
{
    public class Transform : JsonSerializable
    {
        public Vector3 LocalPosition;
        public float LocalRotation;

        public Component Parent { get; private set; }

        public Transform ParentTransform
        {
            get
            {
                var parentComponent = this.Parent.Parent;
                if (parentComponent == null) return null;
                return parentComponent.Transform;
            }
        }

        public Vector3 Position => this.ParentTransform == null ? this.LocalPosition : this.ParentTransform.Position + this.LocalPosition;
        public float Rotation => this.ParentTransform == null ? this.LocalRotation : this.ParentTransform.Rotation + this.LocalRotation;

        public Transform(Component parent)
        {
            this.Parent = parent;
        }

        public override JClass Serialize()
        {
            var jObj = new JClass(this);
            jObj.Add("Position", this.LocalPosition.Serialize());
            jObj.Add("Rotation", this.LocalRotation);
            return jObj;
        }
    }
}
