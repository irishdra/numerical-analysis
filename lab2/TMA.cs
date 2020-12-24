using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class TMA
    {
        public static double[,] A = new double[,] {
            { 150, -52, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 19, -87, 33, 0, 0, 0, 0, 0, 0, 0 },
            { 0, -212, 442, 77, 0, 0, 0, 0, 0, 0 },
            { 0, 0, -8, -123, -47, 0, 0, 0, 0, 0 },
            { 0, 0, 0, -110, 630, -160, 0, 0, 0, 0 },
            { 0, 0, 0, 0, -39, -315, 15, 0, 0, 0 },
            { 0, 0, 0, 0, 0, -13, 124, -13, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 5, 31, 14, 0 },
            { 0, 0, 0, 0, 0, 0, 0, -44, 445, 148 },
            { 0, 0, 0, 0, 0, 0, 0, 0, -643, -732 }
        };
        public static double[] B = new double[] { -832, -673, -352, -397, -977, 80, -810, -707, 262, 719 };
        public static void applyMethod()
        {
            double detA = 1;
            int n = A.GetLength(0);

            //знаходимо альфа, бета та гама
            double[] alpha = new double[n];
            double[] beta = new double[n];
            double[] gamma = new double[n];

            alpha[0] = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == (j + 1)) alpha[i] = A[i, j];
                    if (i == j) beta[i] = - A[i, j];
                    if (i == (j - 1)) gamma[i] = A[i, j];
                }
            }
            gamma[n - 1] = 0;

            //знаходимо P та Q
            detA *= beta[0];
            double[] P = new double[n];
            double[] Q = new double[n];

            P[0] = gamma[0] / beta[0];
            Q[0] = -B[0] / beta[0];
            for (int i = 1; i < n; i++)
            {
                P[i] = gamma[i] / (beta[i] - alpha[i] * P[i - 1]);
                detA *= beta[i] - alpha[i] * P[i - 1];
                Q[i] = (alpha[i] * Q[i - 1] - B[i]) / (beta[i] - alpha[i] * P[i - 1]);
            }
            Console.WriteLine("P");
            Auxiliary.printArray(P);
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("\nQ");
            Auxiliary.printArray(Q);
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("\ndetA: " + detA);

            //знаходимо корені
            double[] roots = new double[n];
            roots[n - 1] = (alpha[n - 1] * Q[n - 2] - B[n - 1]) / (beta[n - 1] - alpha[n - 1] * P[n - 2]);
            for (int i = n - 2; i >= 0; i--)
            {
                roots[i] = (P[i] * roots[i + 1]) + Q[i];
            }

            Console.WriteLine("\nRoots");
            Auxiliary.printArray(roots);
        }
    }
}
