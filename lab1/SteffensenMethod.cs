using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    class SteffensenMethod
    {
        public static void applyMethod(Func<double, double> f, double x, double prevX, double eps, int iteration)
        {
            Console.WriteLine("<------Stephensen Method------>");
            do
            {
                prevX = x;
                x = x - Math.Pow(f(x), 2) / (f(x + f(x)) - f(x));
                Console.WriteLine(iteration + ": x_k = " + x);
                iteration++;
            } while (Math.Abs(x - prevX) > eps);

            Console.WriteLine("\nRoot is " + x + ".");
        }
    }
}
