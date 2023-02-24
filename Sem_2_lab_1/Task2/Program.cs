using System;
using System.Globalization;
using System.IO;
using System.Text;

class Class1
{
    static void Main(string[] args)
    {
        // 1) Create new file .txt
        // 2) Write there 2 line of text
        // 3) Read this file
        // 4) Output result in console

        string line;
        try
        {
            StreamWriter sw = new StreamWriter(@"D:\Git\Progects\Sem_2_lab_1\Task1\Text1.txt");

            sw.WriteLine("Hello World!");
            sw.WriteLine("Test Lab 1.");

            sw.Close();

            StreamReader sr = new StreamReader(@"D:\Microsoft Visual Studio\Projects\OP_Sem_2_lab_1\OP_Sem_2_lab_1\Text1.txt");

            line = sr.ReadLine();

            while (line != null)
            {
                Console.WriteLine(line);

                line = sr.ReadLine();
            }

            sr.Close();
        }
        catch
        {

        }
        finally
        {

        }
    }

}
