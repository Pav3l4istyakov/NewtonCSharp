using System.Reflection.Metadata.Ecma335;

namespace NewtonCSharp
{
    internal class Program
    {
        static double[] calculate_coeffs(double[] X, double[] Y)
        {
            int n = X.Length;

            double[] divDiff = new double[n];
            for (int i = 0; i < n; i++)
            {
                divDiff[i] = Y[i];
            }

            double[] a = new double[n];
            a[0] = divDiff[0];
            Console.WriteLine($"Коэффициент a0: {a[0]}");

            for (int k = 1; k < n; k++)
            {
                for (int i = 0; i < n - k; i++)
                {
                    divDiff[i] = (divDiff[i + 1] - divDiff[i]) / (X[i + k] - X[i]);
                }

                a[k] = divDiff[0];

                Console.WriteLine($"Коэффициент a{k}: {a[k]}");
            }

            return a;
        }

        static double newton_interpolate(double[] X, double[]Y, double x_to_find)
        {
            double[] a = calculate_coeffs(X, Y);

            double result = 0;
            double multiplier = 1;
            int n = X.Length;

            for (int i = 0; i < n; i++)
            {
                result += a[i] * multiplier;
                multiplier *= (x_to_find - X[i]);
            }
            return result;
            
        }

        static void Main(string[] args)
        {
            double[] X = { -2, 0, 1, 3 };
            double[] Y = { -1, -1, 2, 14 };
            double x = 2;

            double result = newton_interpolate(X, Y, x);
            Console.WriteLine($"Результат P({x}) = {result}");
        }
    }
}
