using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class Auxiliary
    {
        public static void printExtendedMatrix(double[,] A, double[] b)
        {
            int w = A.GetLength(1);
            int h = A.GetLength(0);
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    Console.Write("{0,9} ", A[i, j].ToString("0.000"));
                    /*Console.Write(String.Format("{0}\t", Math.Round(A[i, j], 3)));*/
                }
                Console.Write("| {0,9} ", b[i].ToString("0.000"));
                /*Console.Write(String.Format("|\t{0}", Math.Round(b[i], 3)));*/
                Console.WriteLine();
            }
        }
        public static void printMatrix(double[,] A)
        {
            int w = A.GetLength(1);
            int h = A.GetLength(0);
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    Console.Write("{0,9} ", A[i, j].ToString("0.000"));
                }
                Console.WriteLine();
            }
        }
        public static void printArray(double[] arr)
        {
            int l = arr.Length;
            for (int i = 0; i < l; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        public static double[,] transponateMatrix(double[,] A)
        {
            int n = A.GetLength(0);
            double[,] AT = new double[n, n];
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    AT[j, i] = A[i, j];
                }
            }
            return AT;
        }
    }
}
