using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    class Variant
    {
        public static double f1(double x)
        {
            return Math.Sqrt(5 - x) * Math.Sin(x) + x * Math.Cos(Math.PI - x);
        }

        public static double f2(double x)
        {
            return x * Math.Cos(Math.Cosh(x - Math.PI)) + 0.3 * x;
        }

        public static double polynom(double x)
        {
            return - 55 * Math.Pow(x, 7) + 119 * Math.Pow(x, 6) +
                    280 * Math.Pow(x, 5) - 634 * Math.Pow(x, 4) -
                    209 * Math.Pow(x, 3) + 514 * Math.Pow(x, 2) +
                    131 * x + 3;
        }
    }
}
