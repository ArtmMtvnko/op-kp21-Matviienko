using System;
using System.Globalization;
using System.IO;
using System.Text;

class Class1
{
    static void Main(string[] args)
    {
        // Use only arrays
        // Read the file
        // Save in odd indexes word, in even indexes - amount
        // Output result

        string line;
        try
        {
            StreamReader sr = new StreamReader(@"D:\Git\Progects\Sem_2_lab_1\Task4\Text4.txt\Text4.csv\Text5.csv");

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