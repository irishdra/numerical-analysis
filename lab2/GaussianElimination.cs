using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class GaussianElimination
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

            double[,] currA = A.Clone() as double[,];
            double[] currB = B.Clone() as double[];

            double[,] prevA = A.Clone() as double[,];
            double[] prevB = B.Clone() as double[];

            double[] roots = new double[n];

            Auxiliary.printExtendedMatrix(currA, currB);

            for (int k = 0; k < n; k++)
            {
                if (A[k,k] == 0)
                {
                    Console.WriteLine("Something went wrong: A[{0}][{0}] = 0!", k);
                    return;
                }

                double mainEl = currA[k, k];
                detA *= mainEl;

                //k-тий рядок на кожному кроці
                for (int j = k; j < n; j++)
                {
                    currA[k, j] = (Double)prevA[k, j] / mainEl;
                }
                currB[k] = (Double)prevB[k] / mainEl;

                //інші рядки
                for (int i = k + 1; i < n; i++)
                {
                    for (int j = k; j < n; j++)
                    {
                        currA[i, j] = prevA[i, j] - (prevA[i, k] * prevA[k, j]) / mainEl;
                    }
                    currB[i] = prevB[i] - (prevB[k] * prevA[i, k]) / mainEl;
                }

                prevA = currA.Clone() as double[,];
                prevB = currB.Clone() as double[];

                Console.WriteLine("------------------------------------------");
                Console.WriteLine("k = " + (k + 1));
                Console.WriteLine("");
                Auxiliary.printExtendedMatrix(currA, currB);
            }
            //корені
            for (int i = n - 1; i >= 0; i--)
            {
                double sum = prevB[i];
                for (int j = n - 1; j >= i + 1; j--)
                {
                    sum = sum - prevA[i, j] * roots[j];
                }
                roots[i] = sum;
            }

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Roots:");
            Auxiliary.printArray(roots);
            Console.WriteLine("\ndetA = " + detA);
            Console.WriteLine("------------------------------------------");
        }
        public static void findInverseMatrix()
        {
            int n = A.GetLength(0);
            double[,] inverseMatrix = new double[n, n];

            for (int m = 0; m < n; m++)
            {
                double[,] currA = A.Clone() as double[,];
                double[,] prevA = A.Clone() as double[,];

                double[] currE = new double[n];
                Array.Fill(currE, 0);
                currE[m] = 1;
                double[] prevE = currE.Clone() as double[];

                double[] roots = new double[n];

                for (int k = 0; k < n; k++)
                {
                    if (A[k, k] == 0)
                    {
                        Console.WriteLine("Something went wrong: A[{0}][{0}] = 0!", k);
                        return;
                    }

                    double mainEl = prevA[k, k];

                    //k-тий рядок на кожному кроці
                    for (int j = k; j < n; j++)
                    {
                        currA[k, j] = (Double)prevA[k, j] / mainEl;
                    }
                    currE[k] = (Double)prevE[k] / mainEl;

                    //інші рядки
                    for (int i = k + 1; i < n; i++)
                    {
                        for (int j = k; j < n; j++)
                        {
                            currA[i, j] = prevA[i, j] - (prevA[i, k] * prevA[k, j]) / mainEl;
                        }
                        currE[i] = prevE[i] - (prevE[k] * prevA[i, k]) / mainEl;
                    }
                    prevA = currA.Clone() as double[,];
                    prevE = currE.Clone() as double[];
                }
                //корені
                for (int i = n - 1; i >= 0; i--)
                {
                    double sum = prevE[i];
                    for (int j = n - 1; j >= i + 1; j--)
                    {
                        sum = sum - prevA[i, j] * roots[j];
                    }
                    roots[i] = sum;
                    inverseMatrix[i, m] = sum;
                }
            }
            Console.WriteLine("Inverse matrix: \n");
            Auxiliary.printMatrix(inverseMatrix);
        }
    }
}
