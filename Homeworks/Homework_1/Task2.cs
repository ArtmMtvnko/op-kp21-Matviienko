using System;
class World
{
    static void Main(string[] args)
    {
        Console.Write("a = ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("b = ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("c = ");
        double c = Convert.ToDouble(Console.ReadLine());

        double p = (a + b + c) / 2;

        double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        Console.WriteLine("square: " + S);
    }
}