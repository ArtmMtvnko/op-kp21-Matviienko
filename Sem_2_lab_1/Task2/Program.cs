using System;
using System.Globalization;
using System.IO;
using System.Text;

class Class1
{
    static void Main(string[] args)
    {
        // Ganarate random numbers
        // Create txt file
        // Write all numbers in file
        // Create another file
        // Write the max value of numbers in new file

        string line;
        try
        {
            StreamWriter sw = new StreamWriter(@"D:\Git\Progects\Sem_2_lab_1\Task2\Text2.txt");

            Random random = new Random();

            for (int i = 1; i <= 15; i++)
            {
                sw.Write(random.Next(0, 1000).ToString() + " ");
            }

            sw.Close();

            StreamReader sr = new StreamReader(@"D:\Git\Progects\Sem_2_lab_1\Task2\Text2.txt");

            line = sr.ReadLine();

            int num = 0;
            string numStr = "";

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != ' ')
                {
                    numStr = numStr + line[i];
                }
                else
                {
                    if (num < Int32.Parse(numStr))
                    {
                        num = Int32.Parse(numStr);
                    }
                    numStr = "";
                }
            }

            string path = @"D:\Git\Progects\Sem_2_lab_1\Task2\MaximumText2.txt";

            File.WriteAllText(path, num.ToString());

        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block");
        }
    }

}
