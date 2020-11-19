using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    class NewtonMethod
    {
        public static void applyMethod(Func<double, double> f, double a, double b, double eps)
        {
            double x = 0, prevX=0;
            if ((f(a) * Auxiliary.getDerivativeValue(f, 2, a)) > 0) x = a;
            else x = b;
            int iteration = 1;

            if (Math.Abs(f(x)) < 5 * eps)
            {
                SteffensenMethod.applyMethod(f, x, prevX, eps, iteration);
                return;
            }

            Console.WriteLine("<------Newton Method------>");
            do
            {
                prevX = x;
                x = x - f(x) / Auxiliary.getDerivativeValue(f, 1, x);
                Console.WriteLine(iteration + ": x_k = " + x);
                iteration++;
                if (Math.Abs(f(x)) < 5 * eps)
                {
                    SteffensenMethod.applyMethod(f, x, prevX, eps, iteration);
                    return;
                }
            } while (Math.Abs(x - prevX) > eps);

            Console.WriteLine("\nRoot is " + x + ".");
        }
    }
}
