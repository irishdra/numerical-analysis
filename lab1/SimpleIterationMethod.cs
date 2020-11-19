using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    class SimpleIterationMethod
    {
        public static bool stopCriterion(double a, double b, double eps, double q)
        {
            return Math.Abs(a - b) <= Math.Abs((1 - q) * eps / q);
        }

        public static void applyMethod(Func<double, double> f, double a, double b, double eps)
        {
            int iteration = 1;
            double lambda = 0, q = 0;
            Func<double, double> phi = (double x) => x - lambda * f(x);
            Func<double, double> df = Auxiliary.getDerivative(f);

            if (Auxiliary.isMonotonous(df, a, b))
            {
                double alpha = Math.Min(df(a), df(b));
                double gamma = Math.Max(df(a), df(b));
                lambda = 2 / (alpha + gamma);
                q = (gamma - alpha) / (gamma + alpha);
                do
                {
                    b = phi(a);
                    if (stopCriterion(a, b, eps, q)) break;
                    a = b;
                    Console.WriteLine(iteration + ": x = " + a);
                    iteration++;
                } while (true);

                Console.WriteLine("\nRoot is " + (a + b) / 2 + ".");
            }
            else Console.WriteLine("Function derivative is not monotonous in the interval.");
        }
    }
}
