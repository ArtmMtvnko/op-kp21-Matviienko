using System;
using System.Globalization;

class Card
{
    static void Main(string[] args)
    {
        // Вводимо числа
        Console.WriteLine("Enter the x number: ");
        double x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the n number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        // Сталі
        double xPow = x;
        int nCounter = Math.Abs(n);

        // Перевірка на нульовий степінь/факторіал
        if (n == 0)
        {
            Console.WriteLine("x power n is: 1");
            Console.WriteLine("n factorial is: 1");
        }
        else
        {
            // Цикл який множить Х на себе N разів
            for (int i = 1; i < nCounter; i++)
            {
                x *= xPow;

                // Перевірка аби значення не виводилось кожен цикл
                if (i == nCounter - 1)
                {
                    // Перевірка на нуль у від'ємному степені
                    if (x == 0 && n < 0)
                    {
                        Console.WriteLine("Error, 0 in negavive power is division by zero");
                    }
                    // Перевірка на від'ємний степінь
                    else if (n < 0 && x != 0)
                    {
                        x = (1 / x);
                        Console.WriteLine("x power n is: " + x);
                    }
                    // Вивід значення у консоль
                    else
                    {
                        Console.WriteLine("x power n is: " + x);
                    }
                }
            }

            // перевірка чи N є натуральне (та 0) для обчислення факторіалу
            if (n >= 0)
            {
                // Цикл для обчислення факторіалу та виводу його у консоль
                for (int i = nCounter - 1; i > 0; i--)
                {
                    n *= i;
                    if (i == 1)
                    {
                        Console.WriteLine("n factorial is: " + n);
                    }
                }
            }
            // для від'ємних значень факторіалу не існує
            else
            {
                Console.WriteLine("Factorial not determined for negative numbers");
            }
        }
    }

}