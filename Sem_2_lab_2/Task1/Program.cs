using System;
using System.Text;
using System.IO;

namespace OP_Sem_2_Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  
             *  Створити класс для виведення інтерфейту у консоль
             *  Записати результати таблиці у .csv файл
             *  Надати доступ до таблиці через .csv файл
             *  
             */

            // Для коректного відображення текста Кирилицею
            Console.OutputEncoding = Encoding.UTF8;

            ConsoleInterface mainMenu = new ConsoleInterface();

            while (true)
            {
                mainMenu.MenuLength = 0;
                mainMenu.PrintMenuItem("1. Додати людину");
                mainMenu.PrintMenuItem("2. Видалити людину");
                mainMenu.PrintMenuItem("3. Змінити параметри");

                int menuNumber = mainMenu.GetCheckedInput();

                switch (menuNumber)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Вкажіть прізвище");
                        // видаляємо зайві пробіли
                        string name = Console.ReadLine().Replace(" ", "");

                        WriterName lastName = new WriterName(@"D:\Microsoft Visual Studio\Projects\OP_Sem_2_Lab_2\OP_Sem_2_Lab_2\table.csv");
                        lastName.Input(name);

                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Вкажіть рядок, який ви бажаєте видалити");
                        int deleteLineNumber = Int32.Parse(Console.ReadLine().Replace(" ", ""));

                        DeleteLine deleteLine = new DeleteLine(@"D:\Microsoft Visual Studio\Projects\OP_Sem_2_Lab_2\OP_Sem_2_Lab_2\table.csv");
                        deleteLine.Delete(deleteLineNumber);

                        // !!!!! _menuLength, об'єднати класси видалення і запису
                        // аби _menuLength змінювався, і зробити перевірку на вравильність введення

                        // Console.Clear();
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }

            }


            Console.WriteLine("out of range");
        }
    }

    class ConsoleInterface
    {
        private int _menuLength = 0;

        public int MenuLength
        {
            get { return _menuLength; }
            set { _menuLength = value; }
        }

        public void PrintMenuItem(string str)
        {
            Console.WriteLine(str);
            _menuLength++;
        }

        public int GetCheckedInput()
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
                    return num;
                }
                catch
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }

    abstract class Writer
    {
        protected string _path;
        public abstract void Input(string massage);
    }

    class WriterName : Writer
    {
        public WriterName(string path)
        {
            _path = path;
        }

        // мб видалити проперті
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public override void Input(string massage)
        {
            // true - означає, що ми не перезаписуємо файл, а відкриваємо і записуємо у кінець файла
            using (StreamWriter sw = new StreamWriter(_path, true))
            {
                sw.WriteLine(massage);
                sw.Close(); // Flush()
            }
        }
    }

    abstract class Deleter
    {
        protected string _path;
        public abstract void Delete(int NumberOfline);
    }

    class DeleteLine : Deleter
    {
        public DeleteLine(string path)
        {
            _path = path;
        }

        public override void Delete(int NumberOfline)
        {
            List<string> lines = new List<string>();

            // true - означає, що ми не перезаписуємо файл, а відкриваємо і записуємо у кінець файла
            using (StreamReader sr = new StreamReader(_path, true))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }

                sr.Close(); // Flush()
            }

            lines.RemoveAt(NumberOfline - 1);

            using (StreamWriter sw = new StreamWriter(_path))
            {
                foreach (string line in lines)
                {
                    sw.WriteLine(line);
                }

                sw.Close();
            }
        }
    }
}