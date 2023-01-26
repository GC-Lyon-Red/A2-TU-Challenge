using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge
{
    public struct Vector2
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 operator +(Vector2 left, Vector2 right)
            => new Vector2(left.X + right.X, left.Y + right.Y);
        public static bool operator ==(Vector2 l, Vector2 r)
            => l.X == r.X && l.Y == r.Y;
        public static bool operator !=(Vector2 l, Vector2 r)
            => (l == r) == false;

    }

}
