using System;
using System.Security.Cryptography.X509Certificates;

class Pyramid
{
    static void Main(string[] args)
    {
        // add function for calculate factorial
        static int Fac(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        // input a value
        Console.WriteLine("Enter a Sinus value (in degrees): ");
        int degrees = Convert.ToInt32(Console.ReadLine());

        /*  // Prototype of check on right input
        if (degrees.GetTypeCode() != TypeCode.Int32)
        {
            Console.WriteLine("Error of input");
        }
        */

        // this check made for correct caclulate of big numbers
        if (degrees > 360 || degrees < -360)
        {
            degrees %= 360;
            if (degrees > 180)
            {
                degrees -= 360;
            }
            if (degrees < -180)
            {
                degrees += 360;
            }
        }

        // convert degrees in radians
        double x = degrees * (Math.PI / 180);

        // add variable that summarizes values
        double algebraicSum = 0.0;
        // cycle that calculate according formula
        for (int i = 0; i <= 5; i++)
        {
            algebraicSum += Math.Pow((-1), i) * (Math.Pow(x, (2 * i + 1))) / Fac(2 * i + 1);
        }
        // output result
        Console.WriteLine("Value is: " + Math.Round(algebraicSum, 3));
        // compare with built-in method
        Console.WriteLine("Control value with defaul library: " + Math.Round(Math.Sin(x), 3));
    }

}