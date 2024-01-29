using System;
using System.Globalization;

class Card
{
    static void Main(string[] args)
    {
	// Створюємо змінні 
        int oddSum = 0;
        int evenSum = 0;

        string x = Console.ReadLine();
	
	// Цикл який вибирає непарні числа
        for (int i = 0; i < x.Length; i += 2)
        {
	    // Конвертуємо char у число, множимо на 2 кожне з них, конвертуємо отриманні значення у строку
            int intVal = (int)Char.GetNumericValue(x[i]);
            int mult = intVal * 2;
            string elem = mult.ToString();
	    
    	    // Цикл сумує розряди отриманних чисел
            for (int j = 0; j < elem.Length; j++)
            {
                int intValSecond = (int)Char.GetNumericValue(elem[j]);
                oddSum += intValSecond;
            }
        }

  	// Цикл який вибирає парні числа
        for (int q = 1; q < x.Length; q += 2)
        {
	    // конвертуємо char у число, та сумуємо отриманні цифри
            int intVal = (int)Char.GetNumericValue(x[q]);
            evenSum += intVal;
        }

	// перевіряємо чи сумма кратна 10, та виводимо відповідні значення
        if ((oddSum + evenSum) % 10 == 0)
        { 
            Console.WriteLine("Card is valid");
        }
        else
        {
            Console.WriteLine("Card is invalid");
        }

    }

}