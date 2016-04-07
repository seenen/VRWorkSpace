using ProtoBuf;
using System;

namespace LibraryGeometryFormat
{
    [Serializable]
    [ProtoContract]
    public class _Vector2
    {
        [ProtoBuf.ProtoMember(1)]
        public float X;

        [ProtoBuf.ProtoMember(2)]
        public float Y;

        public _Vector2()
        {
            X = 0;
            Y = 0;
        }

        public _Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
