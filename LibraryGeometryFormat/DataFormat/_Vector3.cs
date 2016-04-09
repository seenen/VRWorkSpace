using ProtoBuf;
using System;

namespace LibVRGeometry
{
    [Serializable]
    [ProtoContract]

    public class _Vector3
    {
        [ProtoBuf.ProtoMember(1)]
        public float X;
        [ProtoBuf.ProtoMember(2)]
        public float Y;
        [ProtoMember(3)]
        public float Z;

        public _Vector3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public _Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float Dot(_Vector3 rhs)
        {
            var result = this.X * rhs.X + this.Y * rhs.Y + this.Z * rhs.Z;
            return result;
        }

        public float Magnitude()
        {
            double result = Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);

            return (float)result;
        }

        public _Vector3 Cross(_Vector3 rhs)
        {
            return new _Vector3(
                this.Y * rhs.Z - rhs.Y * this.Z,
                this.Z * rhs.X - rhs.Z * this.X,
                this.X * rhs.Y - rhs.X * this.Y);
        }

        public _Vector3 Normalize()
        {
            var frt = (float)Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);

            return new _Vector3(X / frt, Y / frt, Z / frt);
        }

        public static _Vector3 operator -(_Vector3 lhs, _Vector3 rhs)
        {
            return new _Vector3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }

        public static _Vector3 operator +(_Vector3 lhs, _Vector3 rhs)
        {
            return new _Vector3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
        }

        public static _Vector3 operator /(_Vector3 lhs, float rhs)
        {
            return new _Vector3(lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs);
        }
    }
}
