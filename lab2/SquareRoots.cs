using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class SquareRoots
    {
        public static double[,] A = new double[,] {
            { 106, 59, 8, 70, 6, 19, 49, 6, 13, 44 },
            { 59, 152, 33, 111, 61, 96, 8, 78, 70, 83 },
            { 8, 33, 104, 20, 21, 66, 45, 6, 54, 81 },
            { 70, 111, 20, 148, 17, 109, 36, 63, 22, 32 },
            { 6, 61, 21, 17, 49, 40, 7, 25, 58, 49 },
            { 19, 96, 66, 109, 40, 133, 47, 59, 60, 55 },
            { 49, 8, 45, 36, 7, 47, 152, 12, 39, 46 },
            { 6, 78, 6, 63, 25, 59, 12, 123, 52, 30 },
            { 13, 70, 54, 22, 58, 60, 39, 52, 111, 84 },
            { 44, 83, 81, 32, 49, 55, 46, 30, 84, 144 }
        };
        public static double[] B = new double[] { 154, 13, 64, 37, 125, 27, 10, 91, 136, 60 };
        public static void applyMethod()
        {
            double detA = 1;
            int n = A.GetLength(0);

            //знаходимо U
            double[,] U = new double[n, n];
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i == j)
                    {
                        double sum = 0;
                        for (int k = 1; k <= i - 1; k++)
                        {
                            sum += Math.Pow(U[k - 1, i - 1], 2);
                        }
                        U[i - 1, i - 1] = Math.Sqrt(A[i - 1, i - 1] - sum);
                        detA *= Math.Pow(U[i - 1, i - 1], 2);
                    }
                    else if (j > i)
                    {
                        double sum = 0;
                        for (int k = 1; k <= i - 1; k++)
                        {
                            sum += U[k - 1, i - 1] * U[k - 1, j - 1];
                        }
                        U[i - 1, j - 1] = 1 / U[i - 1, i - 1] * (A[i - 1, j - 1] - sum);
                    }
                    else
                    {
                        U[i - 1, j - 1] = 0;
                    }
                }
            }

            Console.WriteLine("U");
            Auxiliary.printMatrix(U);
            Console.WriteLine("------------------------------------------");

            //знаходимо транспоновану U
            double[,] UT = Auxiliary.transponateMatrix(U);
            Console.WriteLine("Transponated U");
            Auxiliary.printMatrix(UT);
            Console.WriteLine("------------------------------------------");

            //розв'язуємо перше рівняння
            Console.WriteLine("UT * y = b");
            double[] y = new double[n];
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int k = i -1; k >= 0; k--)
                {
                    sum += y[k] * UT[i, k];
                }
                y[i] = (B[i] - sum) / UT[i, i];
            }
            Console.WriteLine("y");
            Auxiliary.printArray(y);
            Console.WriteLine("------------------------------------------");

            //розв'язуємо друге рівняння
            Console.WriteLine("U * x = y");
            double[] x = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int k = i + 1; k < n; k++)
                {
                    sum += x[k] * U[i, k];
                }
                x[i] = (y[i] - sum) / U[i, i];
            }
            Console.WriteLine("x");
            Auxiliary.printArray(x);
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("detA = " + detA);

            //шукаємо обернену матрицю -> Ut*y=ei & U*x=y
            double[,] inverseMatrix = new double[n, n];
            for (int k = 0; k < n; k++)
            {
                double[] E = new double[n];
                Array.Fill(E, 0);
                E[k] = 1;

                //y
                double[] y1 = new double[n];
                for (int i = 0; i < n; i++)
                {
                    double sum = 0;
                    for (int p = i - 1; p >= 0; p--)
                    {
                        sum += y1[p] * UT[i, p];
                    }
                    y1[i] = (E[i] - sum) / UT[i, i];
                }

                //x
                double[] x1 = new double[n];
                for (int i = n - 1; i >= 0; i--)
                {
                    double sum = 0;
                    for (int p = i + 1; p < n; p++)
                    {
                        sum += x1[p] * U[i, p];
                    }
                    x1[i] = (y1[i] - sum) / U[i, i];
                }

                for (int i = 0; i < n; i++)
                {
                    inverseMatrix[i, k] = x1[i];
                }
            }
            Console.WriteLine("\nInverse matrix");
            Auxiliary.printMatrix(inverseMatrix);
        }        
    }
}
