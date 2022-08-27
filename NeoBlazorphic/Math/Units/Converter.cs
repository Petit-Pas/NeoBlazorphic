using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoBlazorphic.Math.Units
{
    public static class Converter
    {
        public static double ToRadian(double angleInDegree)
        {
            return angleInDegree * System.Math.PI / 180;
        }

        public static double ToDegree(double angleInRadian)
        {
            return angleInRadian * 180 / System.Math.PI;
        }
    }
}
