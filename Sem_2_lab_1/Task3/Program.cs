using System;
using System.Globalization;
using System.IO;
using System.Text;

class Class1
{

    static bool CompareWords(string word1, string word2)
    {
        int size;
        if (word1.Length < word2.Length)
        {
            size = word1.Length;
        }
        else
        {
            size = word2.Length;
        }

        for (int i = 0; i < size; i++)
        {
            if (word1[i] < word2[i])
            {
                return false;
            }
            else if (word1[i] > word2[i])
            {
                return true;
            }
        }
        return word1.Length >= word2.Length;
    }

    static bool TestCompareWords()
    {
        // Метод повинен повертати True якщо слово 2 стоїть за алфавітним
        // порядком раніше за слово1

        bool expected1 = false;  // "airplane" and "book"
        bool expected2 = true;   // "celebrity" and "access"
        bool expected3 = false;  // "weekend" and "window"
        bool expected4 = true;   // "computer" and "commission"

        bool actual1 = CompareWords("airplane", "book");
        bool actual2 = CompareWords("celebrity", "access");
        bool actual3 = CompareWords("weekend", "window");
        bool actual4 = CompareWords("computer", "commission");

        if (expected1 != actual1)
        {
            Console.WriteLine("TestCompareWords: Case1 was FAILED");
            return false;
        }
        if (expected2 != actual2)
        {
            Console.WriteLine("TestCompareWords: Case2 was FAILED");
            return false;
        }
        if (expected3 != actual3)
        {
            Console.WriteLine("TestCompareWords: Case3 was FAILED");
            return false;
        }
        if (expected4 != actual4)
        {
            Console.WriteLine("TestCompareWords: Case4 was FAILED");
            return false;
        }
        Console.WriteLine("All cases successful");
        return true;
    }
    static void Main(string[] args)
    {
        // Read the lines
        // Save strings in array
        // Sort array
        // Write words in new file

        TestCompareWords();

        string line;
        try
        {
            StreamReader sr = new StreamReader(@"D:\Microsoft Visual Studio\Projects\OP_Sem_2_lab_1\OP_Sem_2_lab_1\Text3.txt");

            string[] words = new string[40];

            line = sr.ReadLine();

            int index = 0;

            while (line != null)
            {
                words[index] = line;
                index++;
                line = sr.ReadLine();
            }


            for (int i = 0; i < words.Length; i++)
            {
                string key = words[i];
                int j = i - 1;

                while (j >= 0 && CompareWords(words[j], key))
                {
                    words[j + 1] = words[j];
                    j--;
                }

                words[j + 1] = key;
            }

            sr.Close();

            StreamWriter sw = new StreamWriter(@"D:\Microsoft Visual Studio\Projects\OP_Sem_2_lab_1\OP_Sem_2_lab_1\SortedText3.txt");

            foreach (string word in words)
            {
                sw.WriteLine(word);
            }

            sw.Close();
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
