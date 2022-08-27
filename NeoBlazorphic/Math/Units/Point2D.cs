using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoBlazorphic.Math.Units
{
    public sealed record Point2D : IEquatable<Point2D>
    {
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }


        bool IEquatable<Point2D>.Equals(Point2D? other)
        {
            if (other == null)
            {
                return false;
            }
            return X == other.X && Y == other.Y;
        }
    }
}
