using System;
using System.Text;
using System.IO;
using System.ComponentModel.Design;
using System.Linq;

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

            Editor editor = new Editor(@"D:\Microsoft Visual Studio\Projects\OP_Sem_2_Lab_2\OP_Sem_2_Lab_2\table.csv");
            editor.PullChanges();

            ConsoleInterface mainMenu = new ConsoleInterface();

            while (true)
            {
                mainMenu.MenuLength = 0;
                mainMenu.PrintMenuItem("1. ������ ������");
                mainMenu.PrintMenuItem("2. �������� ������");
                mainMenu.PrintMenuItem("3. �������� ����");

                editor.ShowItems();

                int menuNumber = mainMenu.GetCheckedInput();

                switch (menuNumber)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("������ �������");
                        string name = Console.ReadLine().Replace(" ", ""); // ��������� ���� ������

                        Console.WriteLine("������ �������� ������");
                        int salary = Int32.Parse(Console.ReadLine().Replace(" ", ""));

                        Console.WriteLine("������ �������� �/�");
                        int holdedSalary = Int32.Parse(Console.ReadLine().Replace(" ", ""));

                        editor.AddItem(new Person(name, salary, holdedSalary));

                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();

                        Console.WriteLine("������ �����, ���� �� ������ ��������");
                        int deleteNumber = Int32.Parse(Console.ReadLine().Replace(" ", ""));

                        editor.DeleteItem(deleteNumber);

                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("� ����� ���� �������, ����� ����������� ����������� � ���� ;)");
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
        private string _path;
        protected List<string> lines = new List<string>();

        public Editor(string path)
        {
            _path = path;
        }

        private void WriteChangesToFile()
        {
            using (StreamWriter sw = new StreamWriter(_path, false))
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    sw.WriteLine($"{i + 1},{lines[i]}");
                }
            }
        }

        public void AddItem(Person person)
        {
            lines.Add(person.ToString());
            WriteChangesToFile();
        }

        public void AddItem(string name = "undefined", int salary = 0, int holdedSalary = 0)
        {
            lines.Add(new Person(name, salary, holdedSalary).ToString());
            WriteChangesToFile();
        }

        public void DeleteItem(int numberOfLine)
        {
            lines.RemoveAt(--numberOfLine);
            WriteChangesToFile();
        }

        public void DeleteItem(string name)
        {
            foreach (string line in lines)
            {
                if (line.Split(',')[0] != name) continue;
                lines.Remove(line);
                break;
            }
            WriteChangesToFile();
        }

        public void PullChanges()
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string result = string.Join(',', parts.Skip(1)); // String.Join(); s(S)
                    lines.Add(result);
                }
            }
        }

        public void ShowItems()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < lines.Count; i++)
            {
                Console.WriteLine($"{i + 1},{lines[i]}");
            }
            Console.ResetColor();
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

}