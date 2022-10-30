using System;
using System.Globalization;

class Card
{
    static void Main(string[] args)
    {
        // Вводимо число яке хочемо перевірити
        Console.Write("Enter the number: ");
        int prime = Convert.ToInt32(Console.ReadLine());
        // завдяки ідентифікатору не буде виводитися два Console.Write
        byte identificator = 0;

        if (prime < 0)
        {
            Console.WriteLine("Not prime");
        }
        else
        {
            // цикл який пробігається по числам аби перевірити чи число є просте
            for (int i = 2; i <= prime - 1; i++)
            {
                // якщо знайдеться число, яке ділиться без остачі (окрім 1 та n), то воно не просте
                if (prime % i == 0)
                {
                    identificator = 1;
                    Console.WriteLine("Not prime");
                    break;
                }
            }
        }

        // якщо ж не знайшлося, то число просте
        if (identificator == 0 && prime > 0) 
        {
            Console.WriteLine("Prime");
        }


    }

}