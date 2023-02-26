using System;
using System.Globalization;
using System.IO;
using System.Text;

class Class1
{
    
    static void Main(string[] args)
    {
        // Create binary file that copy content of .csv file
        // Read the binary file
        // Sorted stutents with score > 95
        // Write sorted students and theirs amount in new binary file

        string line;
        try
        {
            StreamReader sr = new StreamReader(@"D:\Git\Progects\Sem_2_lab_1\Task6\Text6.csv");
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