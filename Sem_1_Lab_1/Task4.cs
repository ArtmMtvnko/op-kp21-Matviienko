using System;
using System.Security.Cryptography.X509Certificates;

class Pyramid
{
    static void Main(string[] args)
    {
        static int Fac(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        Console.WriteLine("Enter a Sinus value (in degrees): ");
        int degrees = Convert.ToInt32(Console.ReadLine());
        double x = degrees * (Math.PI / 180);

        double algebraicSum = 0.0;
        for (int i = 0; i <= 5; i++)
        {
            algebraicSum += Math.Pow((-1), i) * (Math.Pow(x, (2 * i + 1))) / Fac(2 * i + 1);
        }
        Console.WriteLine("Value is: " + Math.Round(algebraicSum, 3));
        Console.WriteLine("Control value with defaul library: " + Math.Round(Math.Sin(x), 3));
    }

}