using System;
class World
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your rows number: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < rows; i++)
        {
            int val = 1;
            for (int j = 0; j <= i; j++)
            {
                Console.Write($" {val} ");
                val = val * (i - j) / (j + 1);
            }
            Console.WriteLine();
        }
    }
    
}