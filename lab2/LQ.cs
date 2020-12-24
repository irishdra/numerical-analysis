using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class LQ
    {
        public static double[,] A = new double[,] {
            { -68, -18, 95, -91, -55, 67, -64, 1, -63 },
            { 60, 35, -73, 84, 66, -5, 87, 24, -43 },
            { -96, 15, -85, 77, -91, -38, 75, -31, 50 },
            { -74, 70, -42, -48, 96, 12, -41, -23, 84 },
            { -42, -64, 47, -61, 12, 66, 15, 95, -89 },
            { -65, -24, -33, 63, -91, 39, -22, -50, 41 },
            { 40, -25, -32, -75, -93, 67, -74, -21, -42 },
            { -87, -60, -22, 25, 51, -94, 5, 59, 15 },
            { -20, -72, 88, 79, 92, 52, 8, -79, -36 }
        };
        public static double[] B = new double[] { -54, -98, -54, -43, 88, 89, -52, 69, -48 };
        public static void applyMethod()
        {
            double detA = 1;
            int n = A.GetLength(0);
            double[,] currA = new double[n, n];
            double[,] prevA = A.Clone() as double[,];

            double betta = 0;
            double m = 0;
            double[] w = new double[n]; //i
            double[,] H = new double[n, n]; //i

            double[,] Qt = new double[n, n];

            double[,] I = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j) I[i, j] = 1;
                    else I[i, j] = 0;
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                //знаходимо betta, m та w
                double sum = 0;
                for (int k = i; k < n; k++)
                {
                    sum += Math.Pow(prevA[i, k], 2);
                }
                betta = Math.Sign(-prevA[i, i]) * Math.Sqrt(sum);
                m = 1 / Math.Sqrt(2 * Math.Pow(betta, 2) - 2 * betta * prevA[i, i]);
                for (int j = 0; j < n; j++)
                {
                    w[j] = m * prevA[i, j];
                    if (j == i) w[j] -= m * betta;
                    if (i != 0)
                    {
                        for (int k = 0; k < i; k++)
                        {
                            w[k] = 0;
                        }
                    }
                }

                //знаходимо Hi
                for (int l = 0; l < n; l++)
                {
                    for (int p = 0; p < n; p++)
                    {
                        H[l, p] = I[l, p] - 2 *w[l] * w[p];
                    }
                }

                //знаходимо Qt
                double[,] q = new double[n, n];
                if (i == 0) Qt = H.Clone() as double[,];
                else
                {
                    for (int l = 0; l < n; l++)
                    {
                        for (int p = 0; p < n; p++)
                        {
                            double buff = 0;
                            for (int k = 0; k < n; k++)
                            {
                                buff += Qt[l, k] * H[k, p];
                            }
                            q[l, p] = buff;
                        }
                    }
                    Qt = q.Clone() as double[,];
                }

                //знаходимо Ai
                for (int l = 0; l < n; l++)
                {
                    for (int p = 0; p < n; p++)
                    {
                        double buff = 0;
                        for (int k = 0; k < n; k++)
                        {
                            buff += prevA[l, k] * H[k, p];
                        }
                        currA[l, p] = buff;
                    }
                }
                Console.WriteLine("i = {0}", i);

                Console.WriteLine("\nA");
                Auxiliary.printMatrix(prevA);

                prevA = currA.Clone() as double[,];
                
                Console.WriteLine("\nbetta{0} = {1}", i, betta);
                Console.WriteLine("\nm{0} = {1}", i, m);
                Console.WriteLine("\nw{0}", i);
                Auxiliary.printArray(w);
                Console.WriteLine("\nH{0}", i);
                Auxiliary.printMatrix(H);
                Console.WriteLine("\nA{0}", i);
                Auxiliary.printMatrix(currA);
                Console.WriteLine("------------------------------------------\n");
            }

            //detA
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j) detA *= currA[i, j];
                }
            }
            Console.WriteLine("detA = " + detA);

            //знаходимо y
            double[] y = new double[n];
            y[0] = B[0] / currA[0, 0];
            for (int i = 1; i < n; i++)
            {
                double sum = 0;
                for (int k = 0; k < i; k++)
                {
                    sum += y[k] * currA[i, k];
                }
                y[i] = (B[i] - sum) / currA[i, i];
            }
            Console.WriteLine("y");
            Auxiliary.printArray(y);

            //знаходимо x
            double[] x = new double[n];
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += Qt[i, j] * y[j];
                }
                x[i] = sum;
            }

            Console.WriteLine("\nRoots:");
            Auxiliary.printArray(x);
        }
    }
}
