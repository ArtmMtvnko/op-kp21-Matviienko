using System;
using System.Globalization;

class Card
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the x number: ");
        double x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the n number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int xPow = n;
        int nCounter = Math.Abs(n);

        if (n == 0)
        {
            Console.WriteLine("x power n is: 1");
            Console.WriteLine("n factorial is: 1");
        }
        else
        {
            for (int i = 1; i < nCounter; i++)
            {
                x *= xPow;

                if (i == nCounter - 1)
                {
                    if (xPow < 0)
                    {
                        x = Math.Abs(1 / x);
                    }
                    Console.WriteLine("x power n is: " + x);
                }
            }

            if (n >= 0)
            {
                for (int i = nCounter - 1; i > 0; i--)
                {
                    n *= i;
                    if (i == 1)
                    {
                        Console.WriteLine("n factorial is: " + n);
                    }
                }
            }
            else
            {
                Console.WriteLine("Factorial not determined for negative numbers");
            }
        }
    }

}