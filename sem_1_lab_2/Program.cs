using System;
using System.ComponentModel;
using System.Globalization;
using System.Numerics;
using System.Xml;
class Percolate
{
    static int[,] init(int n)
    {
        int[,] matrix = new int[n + 1, n + 1];

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                matrix[i, j] = 0;
            }
        }

        return matrix;
    }

    static void open(int row, int column)
    {

    }

    static bool isOpen(int row, int column)
    {
        return false;
    }

    static bool isFull(int row, int column)
    {
        return false;
    }

    static int numberOfOpenSites()
    {
        return 0;
    }

    static bool percolates()
    {
        return false;
    }

    static void print(int[,] matrix, int size)
    {
        for (int i = 1; i <= size; i++)
        {
            for (int j = 1; j <= size; j++)
            {
                if (matrix[i, j] == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                if (matrix[i, j] == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                if (matrix[i, j] == 2)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.BackgroundColor = ConsoleColor.Black;
    }
    static void Main(string[] args)
    {
        /*
         * output -> matrix (percolationg system)
         * output -> menu with tools (different operations with maxrix)
         * input -> number of action
         * output -> matrix with changes
         */

        Console.Write("Enter size of matrix: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] matrix = init(n);

        /*int[,] matrix = new int[n + 1, n + 1];

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                matrix[i, j] = 0;
            }
        }*/


        while (true)
        {
            print(matrix, n);

            Console.WriteLine("Choose the action with matrix: ");
            Console.WriteLine("1 - open site");
            Console.WriteLine("2 - check is site open?");
            Console.WriteLine("3 - check is the site full?");
            Console.WriteLine("4 - output numbers of open sites");
            Console.WriteLine("5 - check does the system percolates");
            Console.WriteLine("6 - exit");

            int num = Convert.ToInt32(Console.ReadLine());
            if (num < 1 || num > 7)
            {
                Console.WriteLine("Error input, enter correctly value 1-6:");
            }

            if (num == 1)
            {
                Console.WriteLine("Enter number of matrix row and column: ");
                Console.Write("Row: ");
                byte row = Convert.ToByte(Console.ReadLine());
                Console.Write("Column: ");
                byte column = Convert.ToByte(Console.ReadLine());
                matrix[row, column] = 1;
            }

            if (num == 2)
            {
                break;
            }

            if (num == 3)
            {
                break;
            }

            if (num == 4)
            {
                break;
            }

            if (num == 5)
            {
                break;
            }

            if (num == 6)
            {
                break;
            }

        }
        Console.WriteLine("end");
    }


}
