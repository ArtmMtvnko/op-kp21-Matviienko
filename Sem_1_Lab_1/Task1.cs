using System;
using System.Globalization;

class Card
{
    static void Main(string[] args)
    {
        // Вводимо значення змінним
        Console.WriteLine("xn =");
        double xn = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("n =");
        double n = Convert.ToDouble(Console.ReadLine());
        double x0 = 1.75;
        double b = 35.4;

        // Цикл вираховує значення Х для кожної "заданої" точки х1,у1 х2,у2 ... х100,у100
        for (int i = 0; i <= n; i++)
        {
            // Рахуємо значення для xn-нного та виводимо значення
            double x = x0 + i * (xn - x0) / n;
            Console.WriteLine($"x{i} = {Math.Round(x, 2)}");
            // Рахуємо значення для уn-нного та виводимо значення
            double y = Math.Pow(10, (-3)) * Math.Sqrt(Math.Pow(Math.Abs(x), 5)) + Math.Log(Math.E, Math.Abs(x + b));
            Console.WriteLine($"y{i} = {Math.Round(y, 2)}");
        }
    }

}