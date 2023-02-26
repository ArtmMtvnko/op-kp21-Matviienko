using System;
using System.Globalization;
using System.IO;
using System.Text;

class Class1
{
    static bool IsUniqueWord(string[] array, string word)
    {
        for (int i = 0; i < array.Length; i += 2)
        {
            if (array[i] == null) break;
            if (array[i].ToLower() == word.ToLower())
            {
                array[i + 1] = (Int32.Parse(array[i + 1]) + 1).ToString();
                return false;
            }
        }
        return true;
    }

    static bool TestIsUniqueWord()
    {
        string[] fruits = { "apple", "1", "banana", "1", "orange", "1" };

        bool expected1 = true;   // {"apple", "banana", "orange"} word pineapple
        bool expected2 = false;  // {"apple", "banana", "orange"} word banana
        bool expected3 = true;   // {"apple", "banana", "orange"} word APPlication
        bool expected4 = false;  // {"apple", "banana", "orange"} word OraNgE

        bool actual1 = IsUniqueWord(fruits, "pineapple");
        bool actual2 = IsUniqueWord(fruits, "banana");
        bool actual3 = IsUniqueWord(fruits, "APPlication");
        bool actual4 = IsUniqueWord(fruits, "OraNgE");

        if (expected1 != actual1)
        {
            Console.WriteLine("TestIsUniqueWord: Case 1 was FAILED");
            return false;
        }
        if (expected2 != actual2)
        {
            Console.WriteLine("TestIsUniqueWord: Case 2 was FAILED");
            return false;
        }
        if (expected3 != actual3)
        {
            Console.WriteLine("TestIsUniqueWord: Case 3 was FAILED");
            return false;
        }
        if (expected4 != actual4)
        {
            Console.WriteLine("TestIsUniqueWord: Case 4 was FAILED");
            return false;
        }
        Console.WriteLine("TestIsUniqueWord was PASSED!");
        return true;
    }
    static void Main(string[] args)
    {
        // Use only arrays
        // Read the file
        // Save in odd indexes word, in even indexes - amount
        // Output result

        TestIsUniqueWord();

        string line;
        string text = "";
        try
        {
            StreamReader sr = new StreamReader(@"D:\Git\Progects\Sem_2_lab_1\Task4\Text4.txt\Text4.csv\Text5.txt");


            line = sr.ReadLine();

            while (line != null)
            {
                text += line;
                line = sr.ReadLine();
            }

            Console.WriteLine(text);

            string[] words = new string[text.Length];
            int freeIndex = 0;
            string buffer = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ' || text[i] == ',' || text[i] == '.')
                {
                    if (buffer != "" && IsUniqueWord(words, buffer))
                    {
                        words[freeIndex] = buffer.ToLower();
                        words[freeIndex + 1] = "1";
                        freeIndex += 2;
                    }
                    buffer = "";
                    continue;
                }
                buffer += text[i];

            }

            for (int i = 0; i < words.Length; i += 2)
            {
                if (words[i] == null) break;
                Console.WriteLine(words[i] + "[" + words[i + 1] + "]");
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