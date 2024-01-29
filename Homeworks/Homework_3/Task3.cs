using System;
using System.Globalization;

class Card
{
    static void Main(string[] args)
    {
        Console.WriteLine("Скiльки треба дати здачi? ");
        int rest = Convert.ToInt32(Console.ReadLine());

        int c25 = 0, c10 = 0, c5 = 0, c1 = 0;

        do
        {
            rest -= 25;
            c25++;
        }
        while (rest >= 25);

        do
        {
            rest -= 10;
            c10++;
        }
        while (rest >= 10);

        do
        {
            rest -= 5;
            c5++;
        }
        while (rest >= 5);

        do
        {
            rest -= 1;
            c1++;
        }
        while (rest >= 1);

        Console.WriteLine($"25 cent = {c25}");
        Console.WriteLine($"10 cent = {c10}");
        Console.WriteLine($"5 cent = {c5}");
        Console.WriteLine($"1 cent = {c1}");
    }

}