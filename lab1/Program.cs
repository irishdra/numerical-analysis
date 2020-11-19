using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {

            int userInput;
            Console.WriteLine("Choose what you want:\n" +
                "0. Exit.\n" +
                "1. First equation in Horde Method.\n" +
                "2. Second equation in Steffensen Method.\n" +
                "3. Second equation in Simple Iterations Method.\n" +
                "4. Output the roots of the algebraic equation by the Lobachevsky method (clarifying - SIM)");
            int.TryParse(Console.ReadLine(), out userInput);

            Console.WriteLine("Enter epsilon or leave empty [ by default eps = 10^(-7) ]:");
            string epsInput = Console.ReadLine();
            double eps = string.IsNullOrEmpty(epsInput) ? Math.Pow(10, -7) : Convert.ToDouble(epsInput);
            double a, b;

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

                        Console.WriteLine("Enter interval start:");
                        a = Convert.ToDouble(Console.ReadLine(), System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                        Console.WriteLine("Enter interval end:");
                        b = Convert.ToDouble(Console.ReadLine(), System.Globalization.CultureInfo.GetCultureInfo("en-US"));

                        if (!Auxiliary.isInputForFuncValid(Variant.f1, a, b)) break;
                        HordeMethod.applyMethod(Variant.f1, eps, a, b);
                        break;
                    case 2:
                        Console.Clear();

                        Console.WriteLine("Enter interval start:");
                        a = Convert.ToDouble(Console.ReadLine(), System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                        Console.WriteLine("Enter interval end:");
                        b = Convert.ToDouble(Console.ReadLine(), System.Globalization.CultureInfo.GetCultureInfo("en-US"));

                        if (!Auxiliary.isInputForFuncValid(Variant.f2, a, b)) break;
                        NewtonMethod.applyMethod(Variant.f2, a, b, eps);
                        break;
                    case 3:
                        Console.Clear();

                        Console.WriteLine("Enter interval start:");
                        a = Convert.ToDouble(Console.ReadLine(), System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                        Console.WriteLine("Enter interval end:");
                        b = Convert.ToDouble(Console.ReadLine(), System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                        if (!Auxiliary.isInputForFuncValid(Variant.f2, a, b)) break;
                        SimpleIterationMethod.applyMethod(Variant.f2, a, b, eps);

                        break;
                    case 4:
                        Console.Clear();
                        LobachevskyMethod.applyMethod(eps);
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
                    "1. First equation in Horde Method.\n" +
                    "2. Second equation in Steffensen's Method.\n" +
                    "3. Second equation in Simple Iterations Method.\n" +
                    "4. Output the roots of the algebraic equation by the Lobachevsky method.");
                int.TryParse(Console.ReadLine(), out userInput);
            }
        }


    }
}


