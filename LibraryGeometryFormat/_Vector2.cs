using System;

namespace LibraryGeometryFormat
{
    [Serializable]
    public class _Vector2
    {
        public float X;
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
