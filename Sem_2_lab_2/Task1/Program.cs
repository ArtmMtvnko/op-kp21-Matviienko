using System;
using System.Text;
using System.IO;
using System.ComponentModel.Design;

namespace OP_Sem_2_Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person a = new Person("loh", 100, 30);
            Person b = new Person("Ivan", 1050, 10);
            Person c = new Person("Andrei", 1900, 1000);

            Editor editor = new Editor();
            editor.AddItem(a);
            editor.AddItem(b);
            editor.AddItem(c);
            editor.AddItem("Molli", 0, 0);

            editor.ShowItems();

            editor.DeleteItem("loh");
            editor.ShowItems();

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
                mainMenu.PrintMenuItem("3. Записати зміни");

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

                        DeleteLine deleteLine = new DeleteLine(@"D:\Microsoft Visual Studio\Projects\OP_Sem_2_Lab_2\OP_Sem_2_Lab_2\table.csv");

                        int deleteLineNumber = deleteLine.GetLineNumber();
                        deleteLine.Delete(deleteLineNumber);

                        Console.Clear();
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

    class Person
    {
        private string _name;
        private int _salary;
        private int _holdedSalary;
        private int _getedSalary;

        public Person(string name, int salary, int holdedSalary)
        {
            _name = name;
            _salary = salary;
            _holdedSalary = holdedSalary;
            _getedSalary = salary - holdedSalary;
        }

        public override string ToString()
        {
            return $"{_name},{_salary},{_holdedSalary},{_getedSalary}";
        }
    }

    class Editor
    {
        protected List<string> lines = new List<string>();

        public void AddItem(Person person)
        {
            lines.Add(person.ToString());
        }

        public void AddItem(string name = "undefined", int salary = 0, int holdedSalary = 0)
        {
            lines.Add(new Person(name, salary, holdedSalary).ToString());
        }

        public void DeleteItem(int numberOfLine)
        {
            lines.RemoveAt(--numberOfLine);
        }

        public void DeleteItem(string name)
        {
            foreach (string line in lines)
            {
                if (line.Split(',')[0] != name) continue;
                lines.Remove(line);
                break;
            }
        }

        public void ShowItems()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                Console.WriteLine($"{i + 1},{lines[i]}");
            }
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

        public override void Delete(int NumberOfLine)
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

            lines.RemoveAt(NumberOfLine - 1);

            using (StreamWriter sw = new StreamWriter(_path))
            {
                foreach (string line in lines)
                {
                    sw.WriteLine(line);
                }

                sw.Close();
            }
        }

        public int GetLineNumber()
        {
            int tableLength = 0;
            using (StreamReader sr = new StreamReader(_path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    tableLength++;
                }
            }
            int deleteLineNumber;
            while (true)
            {
                try
                {
                    deleteLineNumber = Int32.Parse(Console.ReadLine().Replace(" ", ""));
                    if (deleteLineNumber > tableLength || deleteLineNumber < 1)
                    {
                        Console.WriteLine($"Error input, enter correctly value 1-{tableLength}:");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine($"Error input");
                }
            }

            return deleteLineNumber;

        }
    }
}