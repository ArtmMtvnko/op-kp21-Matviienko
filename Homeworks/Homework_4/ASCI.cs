using System;
using System.Globalization;

class ASCI
{
    static void Main(string[] args)
    {
        int size = Convert.ToInt32(Console.ReadLine());
        for (int q = 0; q < size*2; q++)
        {
            Console.Write(" ");
        }
        Console.WriteLine("|<><>|");
        for (int i = 1; i <= size; i++)
        {
            for (int q = 0; q < (size - i)*2; q++)
            {
                Console.Write(" ");
            }
            Console.Write("|<>");
            for (int j = i; j <= i*4+i-1; j++)
            {
                Console.Write($".");
            }
            Console.WriteLine("<>|");
        }
        for (int i = size; i > 0; i--)
        {
            for (int q = 0; q < (size - i)*2; q++)
            {
                Console.Write(" ");
            }
            Console.Write("|<>");
            for (int j = i; j <= i*4+i-1; j++)
            {
                Console.Write($".");
            }
            Console.Write("<>|");
            Console.WriteLine();

        }
        for (int q = 0; q < size*2; q++)
        {
            Console.Write(" ");
        }
        Console.WriteLine("|<><>|");
    }

}
