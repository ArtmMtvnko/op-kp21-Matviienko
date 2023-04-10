using System;
using System.Numerics;
using System.Text;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int[] aa = { 1, 2, 3, 4, 4, 0 };
            Vector a;
            Vector b;

            ConsoleInterface menu = new ConsoleInterface();
            menu.Reset();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(menu.SetMenuItem("Вкажіть координати Vector 1 через кому:"));

                string[] inputVector1 = Console.ReadLine().Replace(" ", "").Split(',');
                if (!menu.CheckInput(inputVector1)) continue;
                int[] arrayOfNumbersVector1 = Array.ConvertAll(inputVector1, Int32.Parse);

                a = new Vector(arrayOfNumbersVector1);

                Console.Clear();
                Console.WriteLine(menu.SetMenuItem("Вкажіть координати Vector 2 через кому:"));

                string[] inputVector2 = Console.ReadLine().Replace(" ", "").Split(',');
                if (!menu.CheckInput(inputVector2)) continue;
                int[] arrayOfNumbersVector2 = Array.ConvertAll(inputVector2, Int32.Parse);

                b = new Vector(arrayOfNumbersVector2);

                break;
            }

            while (true)
            {
                Console.Clear();

                Console.WriteLine(menu.SetMenuItem("1. Сума від’ємних елементів двох \"векторів\"."));
                Console.WriteLine(menu.SetMenuItem("2. Добуток елементів двох \"векторів\" із парними номерами."));
                Console.WriteLine(menu.SetMenuItem("3. Кількість елементів двох \"векторів\", рівних 0."));

                int menuNumber = menu.GetCheckedInput();

                switch (menuNumber)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Відповідь: {a + b}");
                        Console.ResetColor();
                        Thread.Sleep(5000);
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Відповідь: {a * b}");
                        Console.ResetColor();
                        Thread.Sleep(5000);
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Відповідь: {a / b}");
                        Console.ResetColor();
                        Thread.Sleep(5000);
                        break;
                }
            }
        }
    }

    class Vector
    {
        private int[] _coordinates;
        public Vector(params int[] numbers)
        {
            _coordinates = numbers;
        }

        public static int operator +(Vector a, Vector b)
        {
            int summaryNumbers = 0;

            for (int i = 0; i < a._coordinates.Length; i++)
            {
                if (a._coordinates[i] < 0) summaryNumbers += a._coordinates[i];
            }

            for (int i = 0; i < b._coordinates.Length; i++)
            {
                if (b._coordinates[i] < 0) summaryNumbers += b._coordinates[i];
            }

            return summaryNumbers;
        }

        public static int operator *(Vector a, Vector b)
        {
            int multiplyNumbers = 1;

            for (int i = 1; i < a._coordinates.Length; i += 2)
            {
                multiplyNumbers *= a._coordinates[i];
            }

            for (int i = 1; i < b._coordinates.Length; i += 2)
            {
                multiplyNumbers *= b._coordinates[i];
            }

            return multiplyNumbers;
        }

        public static int operator /(Vector a, Vector b)
        {
            int zeroCounter = 0;

            for (int i = 0; i < a._coordinates.Length; i++)
            {
                if (a._coordinates[i] == 0) zeroCounter++;
            }

            for (int i = 0; i < b._coordinates.Length; i++)
            {
                if (b._coordinates[i] == 0) zeroCounter++;
            }

            return zeroCounter;
        }

        public override string ToString()
        {
            string output = "";
            output += _coordinates[0];
            for (int i = 1; i < _coordinates.Length; i++)
            {
                output += "," + _coordinates[i];
            }

            return String.Format("Vector: ( {0} )", output);
        }
    }

    class ConsoleInterface
    {
        private int _menuLength;

        public ConsoleInterface()
        {
            _menuLength = 0;
        }

        public void Reset()
        {
            _menuLength = 0;
        }

        public string SetMenuItem(string message)
        {
            _menuLength++;
            return message;
        }

        public bool CheckInput(string[] values)
        {
            int number;
            foreach (string value in values)
            {
                bool check = int.TryParse(value, out number);
                if (!check) return false;
            }
            return true;
        }

        public void ShowArray(int[] array)
        {
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
        }

        private bool IsInputValid(string input)
        {
            int number;
            bool isNumber = int.TryParse(input, out number);

            if (!isNumber) return false;

            if (number < 0 || number > _menuLength) return false;

            return true;
        }

        public int GetCheckedInput()
        {
            while (true)
            {
                string input = Console.ReadLine().Replace(" ", "");

                if (!IsInputValid(input)) continue;

                return Int32.Parse(input);
            }
        }
    }
}