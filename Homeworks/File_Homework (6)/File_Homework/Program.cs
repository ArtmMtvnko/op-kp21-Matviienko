using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data.Common;
using System.Globalization;
using System.Numerics;
using System.Xml;
using System.IO;
using System.Collections.Immutable;
class FileHomework
{
    static void Main(string[] args)
    {
        string readText = File.ReadAllText("../../../numbers.txt");

        int arrayLength = 0;

        if (Convert.ToString(readText[0]) != " ")
        {
            arrayLength++;
        }

        for (int i = 0; i < readText.Length - 1; i++)
        {
            if (Convert.ToString(readText[i]) == " " && Convert.ToString(readText[i + 1]) != " ")
            {
                arrayLength++;
            }
        }

        string[] numsArray = new string[arrayLength];

        for (int i = 0; i < numsArray.Length - 1;)
        {
            for (int j = 0; j < readText.Length; j++)
            {
                if (readText[j].ToString() == " ")
                {
                    i++;
                }
                else
                {
                    numsArray[i] += readText[j].ToString();
                }
            }
        }

        int[] numsArrayInt = new int[numsArray.Length];

        for (int i = 0; i < numsArray.Length; i++)
        {
            numsArrayInt[i] = Convert.ToInt32(numsArray[i]);
        }

        Array.Sort(numsArrayInt);

        for (int i = 0; i < numsArray.Length; i++)
        {
            numsArray[i] = Convert.ToString(numsArrayInt[i]);
        }

        string result = "";

        for (int i = 0; i < numsArray.Length; i++)
        {
            result += numsArray[i] + " ";
        }

        File.WriteAllText("../../../sorted_numbers.txt", result);

        Console.WriteLine("Numbers have sorted. Now it look like this:");
        for (int i = 0; i < numsArray.Length; i++)
        {
            Console.Write(numsArray[i] + " ");
        }
        Console.WriteLine("\nYou can check the result in the file 'sorted_numbers.txt' ");
    }
}