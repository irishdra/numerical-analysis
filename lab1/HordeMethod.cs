using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    class HordeMethod
    {
        public static void applyMethod(Func<double, double> f, double eps, double a, double b)
        {
            bool isAImmovable = f(a) * Auxiliary.getDerivativeValue(f, 2, a) < 0;

            int iteration = 1;
            double c = 0, prevX = 0;

            do
            {
                prevX = c;
                c = a - (f(a) * (b - a)) / (f(b) - f(a));

                if (isAImmovable) b = c;
                else a = c;
                
                Console.WriteLine(iteration + ": xє[" + a + "; " + b + "];");

                iteration++;
            } while (Math.Abs(c - prevX) > eps);

            Console.WriteLine("\nRoot: " + c + ".");
        }
    }
}
