using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstClass FC = new FirstClass();

            //read
            Console.WriteLine("What is the length of the vectors?");
            var A_length_string = Console.ReadLine();
            int A_length = Int32.Parse(A_length_string);

            double[,] A = new double[2, A_length];

            Console.WriteLine("Input x, then y, elemetwise \n");

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < A_length; j++)
                {
                    Console.Write($"{Environment.NewLine}i={i}, j={j}: \t");
                    A[i, j] = double.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Input z = \t");
            double Az = double.Parse(Console.ReadLine());

            FC.LinInterpolation(A, Az);

            //Console.WriteLine("What is your name?");
            //var name = Console.ReadLine();
            //var currentDate = DateTime.Now;
            //Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d} at {currentDate:t}!");
            Console.Write($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey(true);
        }
    }

    class FirstClass
    {
        public void LinInterpolation(double[,] A, double z)
        {
            int L = A.GetLength(1);
            double[] x = new double[L];
            double[] y = new double[L];

            for (int j = 0; j < L; j++)
            {
                x[j] = A[0, j];
                y[j] = A[1, j];
            }

            if (z < x[0] || z > x[L - 1])
            {
                Console.WriteLine($"z is out of range!");

                return;
            }

            int N = -1;
            int i = 1;
            while (N == -1)
            {
                if (x[i] > z)
                {
                    N = i;
                }
                else
                {
                    i++;
                }
            }
            double k = y[N - 1] + (z - x[N - 1]) / (x[N] - x[N - 1]) * (y[N] - y[N - 1]);

            Console.WriteLine($"{Environment.NewLine}k = f(z) = {k}");

            return;
        }
    }

}