using System;
class Pyramid
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your floor number: ");
        int floors = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < floors; i++)
        {
            for (int s = floors; s > i; s--)
            {
                Console.Write(" ");
            }
            for (int j = 0; j <= i; j++)
            {
                Console.Write("#");
            }

            for (int s = 1; s > 0; s--)
            {
                Console.Write(" ");
            }
            for (int j = 0; j <= i; j++)
            {
                Console.Write("#");
            }
            Console.WriteLine();
        }
    }

}
