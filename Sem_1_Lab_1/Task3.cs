using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml;

class Card
{
    static void Main(string[] args)
    {
        // x^n    n!
        // Вводимо значення
        Console.Write("Enter x value: ");
        double x = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter n value: ");
        long n = Convert.ToInt64(Console.ReadLine());

        // Перевіряємо на правильність вводу
        while (true)
        {
            if (n < 0)
            {
                Console.WriteLine("factorial can't be negative number. Enter again: ");
                n = Convert.ToInt64(Console.ReadLine());
            }
            else
            {
                break;
            }
        }

        // Створюєммо змінну - лічильник (для циклів)
        int counter = Convert.ToInt32(n);

        // Перевітка на 0 степінь/ 0 факторіал
        if (n != 0)
        {
            // Рахуємо степінь
            double xConst = x;
            for (int i = 1; i < counter; i++)
            {
                x *= xConst;
            }
            Console.WriteLine("x^n = " + x);

            // Рахуємо факторіал
            int nConst = Convert.ToInt32(n);
            for (int i = 1; i < counter; i++)
            {
                n *= --nConst;
            }
            Console.WriteLine("n! = " + n);
        }
        else
        {
            Console.WriteLine("x^n = 1");
            Console.WriteLine("n! = 1");
        }
    }

}