using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput;
            Console.WriteLine("Choose what you want:\n" +
                "0. Exit.\n" +
                "1. First system by Gaussian elimination.\n" +
                "2. First system by Reflection method (LQ).\n" +
                "3. Second system by Square root method.\n" +
                "4. Third system by Tridiagonal matrix algorithm.");
            int.TryParse(Console.ReadLine(), out userInput);

            while (userInput != 0)
            {
                switch (userInput)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Have a nice day! :)");
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.Clear();
                        GaussianElimination.applyMethod();
                        GaussianElimination.findInverseMatrix();
                        break;
                    case 2:
                        Console.Clear();
                        LQ.applyMethod();
                        break;
                    case 3:
                        Console.Clear();
                        SquareRoots.applyMethod();
                        break;
                    case 4:
                        Console.Clear();
                        TMA.applyMethod();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Enter correct number of action!");
                        int.TryParse(Console.ReadLine(), out userInput);
                        break;
                }

                Console.WriteLine("\n---------------------------------------------------->>>>>\n" +
                    "Choose what you want:\n" +
                    "0. Exit.\n" +
                    "1. First system by Gaussian elimination.\n" +
                    "2. First system by Reflection method (LQ).\n" +
                    "3. Second system by Square root method.\n" +
                    "4. Third system by Tridiagonal matrix algorithm.");
                int.TryParse(Console.ReadLine(), out userInput);
            }
        }
    }
}
