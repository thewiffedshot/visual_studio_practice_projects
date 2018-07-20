﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace simple_3d_graphics_test
{
    class Quaternion
    {
        public Vector4 Value { get; set; }
        public Vector4 Inverse { get => new Vector4(-Value.X, -Value.Y, -Value.Z, Value.W); }
        public float Angle { get; set; }
        public Vector3 Axis { get; set; }


        public Quaternion(Vector3 axisVector, float angle)
        {
            Angle = angle / 2;
            Vector3 axis = Vector3.Normalize(axisVector);
            Axis = axis;
            Value = new Vector4(Axis.X * (float)Math.Sin(angle / 2), Axis.Y * (float)Math.Sin(angle / 2), Axis.Z * (float)Math.Sin(angle / 2), (float)Math.Cos(angle / 2));
        }

        public Quaternion(Vector3 vector)
        {
            Value = new Vector4(vector, 0);
        }

        public Quaternion(Vector4 vector)
        {
            Value = vector;
        }

        public Vector3 RotateVector(Vector3 vector)
        {
            Quaternion p = new Quaternion(vector);
            Quaternion pRot = new Quaternion(Hamilton(Value, p.Value));
            pRot = new Quaternion(Hamilton(pRot.Value, Inverse));

            return new Vector3(pRot.Value.X, pRot.Value.Y, pRot.Value.Z);
        }

        private static Vector4 Hamilton(Vector4 a, Vector4 b)
        {
            return new Vector4(a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y, a.W * b.Y + a.Y * b.W + a.Z * b.X - a.X * b.Z, a.W * b.Z + a.Z * b.W + a.X * b.Y - a.Y * b.X, a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z);
        }
    }
}
