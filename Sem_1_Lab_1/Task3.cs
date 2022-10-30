using System;
using System.Globalization;

class Card
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the x number: ");
        int x = Convert.ToInt32(Console.ReadLine());
        int xPow = x;
        Console.WriteLine("Enter the n number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int nCounter = n;

        for (int i = 1; i < nCounter; i++)
        {
            x *= xPow;

            if (i == nCounter - 1)
            {
                Console.WriteLine("x power x is: " + x);
            }
        }

        for (int i = nCounter - 1; i > 0; i--)
        {
            n *= i;
            if (i == 1)
            {
                Console.WriteLine("n factorial is: " + n);
            }
        }
    }

}