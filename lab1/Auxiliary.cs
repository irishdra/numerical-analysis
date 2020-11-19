using System;

namespace lab1
{
    class Auxiliary
    {
        public static Func<double, double> getDerivative(Func<double, double> f)
        {
            const double deltaX = 0.000001;
            return (double x0) => (f(x0 + deltaX) - f(x0)) / deltaX;
        }
        
        public static double getDerivativeValue(Func<double, double> f, int order, double x0)
        {
            if (order == 0) return f(x0);
            else
            {
                Func<double, double> df = getDerivative(f);
                return getDerivativeValue(df, order - 1, x0);
            }
        }

        public static bool isRootOnInterval(Func<double, double> f, double a, double b)
        {
            return f(a) * f(b) < 0;
        }

        public static bool isMonotonous(Func<double, double> f, double a, double b)
        {
            double step = 0.0001;
            bool grows = f(a) < f(a + step);
            for (double x = a; x < b; x += step)
            {
                if (f(x) < f(x + step) != grows) return false;
            }
            return true;
        }

        public static bool isInputForFuncValid(Func<double, double> f, double a, double b)
        {
            if (a >= b)
            {
                Console.WriteLine("Invalid interval.");
                return false;
            }
            if (!isRootOnInterval(f, a, b))
            {
                Console.WriteLine("There are no roots in the interval.");
                return false;
            }
            if (!isMonotonous(f, a, b))
            {
                Console.WriteLine("Function is not monotonous in the interval.");
                return false;
            }
            return true;
        }
    }
}
