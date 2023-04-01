using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO2_project
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> f = x => Math.Sqrt(5 * x * x + x + 6) + Math.Sqrt(3 * x + 7);
            double alpha = 0.02; // Calculation step
            double x0 = 0; // Starting point
            int kMax = 200000; // Maximum number of iterations
            double epsX = 0.001; // Precision for x
            double epsF = 0.02; // Precision for f(x)

            // Initialization
            double xk = x0;
            double fk = f(xk);
            double gradFk = (f(xk + epsX) - f(xk - epsX)) / (2 * epsX);
            Console.WriteLine(gradFk);
            int k = 0;

            // Main loop
            while (k < kMax && Math.Abs(gradFk) > epsF && Math.Abs(xk - x0) > epsX)
            {
                x0 = xk;
                fk = f(xk);
                gradFk = (f(xk + epsX) - f(xk - epsX)) / (2 * epsX);
                xk = x0 - alpha * gradFk;
                k++;
            }

            // Output results
            Console.WriteLine("Minimum value: " + fk);
            Console.WriteLine("Minimum point: " + xk);
            Console.WriteLine("Number of iterations: " + k);

            Console.ReadLine();
        }
    }
}
