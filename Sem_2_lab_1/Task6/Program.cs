using System;
using System.Globalization;
using System.IO;
using System.Text;

class Class1
{
    const string path = @"D:\Git\Progects\Sem_2_lab_1\Task6";
    static void Main(string[] args)
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

        // Create binary file that copy content of .csv file
        // Read the binary file
        // Sorted stutents with score > 95
        // Write sorted students and theirs amount in new binary file

        string line;
        string binaryLine;
        try
        {
            StreamReader sr = new StreamReader(Path.Combine(path, "Text6.csv"));

            line = sr.ReadLine();

            BinaryWriter bw;
            BinaryReader br;

            bw = new BinaryWriter(new FileStream(Path.Combine(path, "BinaryText6"), FileMode.Create));

            while (line != null)
            {
                bw.Write(line);
                line = sr.ReadLine();
            }

            bw.Close();

            br = new BinaryReader(new FileStream(Path.Combine(path, "BinaryText6"), FileMode.Open));

            BinaryWriter sort = new BinaryWriter(new FileStream(Path.Combine(path, "SortedBinaryText6"), FileMode.Create));

            binaryLine = br.ReadString();

            try
            {
                while (binaryLine != null)
                {
                    string[] person = SplitText(binaryLine);
                    if (Int32.Parse(person[2]) > 95)
                    {
                        sort.Write(binaryLine);
                        Console.WriteLine(binaryLine);
                    }
                    binaryLine = br.ReadString();
                }
                br.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            sort.Close();


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