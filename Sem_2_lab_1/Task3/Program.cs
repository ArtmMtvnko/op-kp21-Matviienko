using System;
using System.Globalization;
using System.IO;
using System.Text;

class Class1
{
    static void Main(string[] args)
    {
        // Read the lines
        // Save strings in array
        // Sort array
        // Write words in new file

        string line;
        try
        {
            StreamReader sr = new StreamReader(@"D:\Git\Progects\Sem_2_lab_1\Task3\Text3.txt");

            string[] words = new string[40];

            line = sr.ReadLine();

            int index = 0;

            while (line != null)
            {
                words[index] = line;
                index++;
                line = sr.ReadLine();
            }


            foreach (string word in words)
            {
                Console.WriteLine(word);
            }


            for (int i = 0; i < words.Length; i++)
            {
                string key = words[i];
                int j = i - 1;

                while (j >= 0 && words[j][0] > key[0])
                {
                    words[j + 1] = words[j];
                    j--;
                }

                words[j + 1] = key;
            }

            Console.WriteLine();
            Console.WriteLine();

            foreach (string word in words)
            {
                Console.WriteLine(word);
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
