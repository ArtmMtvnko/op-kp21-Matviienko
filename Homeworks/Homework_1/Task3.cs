using System;
class World
{
    static void Main(string[] args)
    {
        int x1 = 0;
        int x2 = 0;
        int y1 = 0;
        int y2 = 0;

        Console.WriteLine("Enter x1: ");
        x1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter x2: ");
        x2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter y1: ");
        y1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter y2: ");
        y2 = Convert.ToInt32(Console.ReadLine());

        int x = x2 - x1;
        int y = y2 - y1;

        double lenght = Math.Round(Math.Sqrt(x*x + y*y), 2);

        Console.WriteLine("Vector lenght is: " + lenght);
    }
}