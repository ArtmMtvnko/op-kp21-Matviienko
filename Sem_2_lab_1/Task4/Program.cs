using System;
using System.Globalization;
using System.IO;
using System.Text;

class Class1
{
    static string[] SplitText(string str)
    {
        string buffer = "";
        string[] result = new string[3];

        int freeIndex = 0;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == ',')
            {
                result[freeIndex] = buffer;
                freeIndex++;
                buffer = "";
            }
            else
            {
                buffer += str[i];
            }
        }
        result[freeIndex] = buffer;
        return result;
    }

    // Unit Test
    static bool TestSplitText()
    {
        string[] expected1 = { "Abigail", "Johnson", "83" };   // Abigail, Johnson, 83
        string[] expected2 = { "Ethan", "Parker", "56" };      // Ethan, Parker, 56
        string[] expected3 = { "Olivia", "Wilson", "32" };     // Olivia, Wilson, 32
        string[] expected4 = { "William", "Garcia", "78" };    // William, Garcia, 78

        string[] actual1 = SplitText("Abigail, Johnson, 83");
        string[] actual2 = SplitText("Ethan, Parker, 56");
        string[] actual3 = SplitText("Olivia, Wilson, 32");
        string[] actual4 = SplitText("William, Garcia, 78");

        if (expected1[0] != actual1[0] && expected1[1] != actual1[1] && expected1[2] != actual1[2])
        {
            Console.WriteLine("TestSplitText: Case 1 was FAILED");
            return false;
        }
        if (expected2[0] != actual2[0] && expected2[1] != actual2[1] && expected2[2] != actual2[2])
        {
            Console.WriteLine("TestSplitText: Case 2 was FAILED");
            return false;
        }
        if (expected3[0] != actual3[0] && expected3[1] != actual3[1] && expected3[2] != actual3[2])
        {
            Console.WriteLine("TestSplitText: Case 3 was FAILED");
            return false;
        }
        if (expected4[0] != actual4[0] && expected4[1] != actual4[1] && expected4[2] != actual4[2])
        {
            Console.WriteLine("TestSplitText: Case 4 was FAILED");
            return false;
        }
        Console.WriteLine("All Cases passed");
        return true;
    }
    static void Main(string[] args)
    {
        // Read the lines of file
        // Split the lines (without method .Split())
        // Sort people by score < 60
        // Output result

        string line;
        try
        {
            StreamReader sr = new StreamReader(@"D:\Git\Progects\Sem_2_lab_1\Task4\Text4.csv");

            TestSplitText();

            line = sr.ReadLine();

            while (line != null)
            {
                string[] result = SplitText(line);
                if (Int32.Parse(result[2]) < 60)
                {
                    Console.WriteLine(result[0] + "," + result[1] + "," + result[2]);
                }
                line = sr.ReadLine();
            }
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