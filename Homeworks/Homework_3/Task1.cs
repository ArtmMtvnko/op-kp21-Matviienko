using System;
class World
{
    static void Main(string[] args)
    {
        // Вводимо змінну (до якого числа виводити таблицю)
        Console.WriteLine("Enter your number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        // Зовнішній цикл виводить кількість рядків
        for (int i = 1; i <= num; i++)
        {
            // Внутрішній цикл виводить кількість стовпців
            for (int j = 1; j <= num; j++)
            {
                // Обчислюємо (заповнюємо) таблицю
                Console.Write($"   {i * j}   ");
            }
            // Переходимо на новий рядок (три для красивого виводу данних)
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }

}
