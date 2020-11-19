using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    class LobachevskyMethod
    {
        public static List<double> decreaseCoeffs(List<double> coeffs)
        {
            List<double> decreasedCoeffs = new List<double> { };
            foreach (var с in coeffs)
            {
                decreasedCoeffs.Add(с / 50);
            }
            return decreasedCoeffs;
        }

        public static bool stopCriterion(List<double> startCoeffs, List<double> endCoeffs, double eps)
        {
            for (int i = 0; i < startCoeffs.Count; i++)
            {
                double difference = Math.Abs(Math.Pow(startCoeffs[i], 2) - endCoeffs[i]);
                if (difference > eps) return false;
            }
            return true;
        }

        public static void applyMethod(double eps)
        {
            List<double> coeffs = new List<double>() { -55, 119, 280, -634, -209, 514, 131, 3 };

            List<double> coeffsA = decreaseCoeffs(coeffs);
            List<double> coeffsB = new List<double>(new double[coeffs.Count]);

            int n = coeffs.Count - 1, p = 0;

            while (!stopCriterion(coeffsA, coeffsB, eps))
            {
                p++;
                for (int k = 0; k <= n; k++)
                {
                    double sum = 0;
                    for (int j = 1; j <= Math.Min(k, n - k); j++)
                    {
                        sum += Math.Pow(-1, j) * coeffsA[k - j] * coeffsA[k + j];
                    }

                    coeffsB[k] = Math.Pow(coeffsA[k], 2) + 2 * sum;
                }

                coeffsA = decreaseCoeffs(coeffsB);
            }

            List<double> roots = new List<double>(new double[coeffs.Count - 1]);
            double root = 0;

            for (int i = 1; i < coeffsA.Count; i++)
            {
                root = Math.Pow(coeffsA[i] / coeffsA[i - 1], Math.Pow(2, -p));

                if (Math.Abs(Variant.polynom(root)) < Math.Abs(Variant.polynom(-root))) roots[i - 1] = root;
                else roots[i - 1] = -root;
            }

            foreach (var r in roots)
            {
                Console.WriteLine("For: " + r + ".");
                double a = r - 0.1;
                double b = r + 0.1;
                SimpleIterationMethod.applyMethod(Variant.polynom, a, b, eps);
                Console.WriteLine("");
            }
        }
    }
}