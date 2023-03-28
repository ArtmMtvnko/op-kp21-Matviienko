using System;
using System.Text;

namespace OP_Sem_2_Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  
             *  �������� ����� ��� ��������� ���������� � �������
             *  �������� ���������� ������� � .csv ����
             *  ������ ������ �� ������� ����� .csv ����
             *  
             */

            // ��� ���������� ����������� ������ ���������
            Console.OutputEncoding = Encoding.UTF8;

            ConsoleInterface menu = new ConsoleInterface();

            menu.PrintMenuItem("1. ������ ������");
            menu.PrintMenuItem("2. �������� ������");
            menu.PrintMenuItem("3. ������ ���������");

            menu.CheckInput();

            Console.WriteLine("out of range");
        }
    }

    class ConsoleInterface
    {
        private int _menuLength = 0;

        public void PrintMenuItem(string str)
        {
            Console.WriteLine(str);
            _menuLength++;
        }

        public void CheckInput()
        {
            while (true)
            {
                try
                {
                    int num = Int32.Parse(Console.ReadLine());
                    if (num < 1 || num > _menuLength)
                    {
                        Console.WriteLine($"Error input, enter correctly value 1-{_menuLength}:");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}