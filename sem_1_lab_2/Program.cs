using System;
using System.ComponentModel;
using System.Data.Common;
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

    static bool isOpen(int row, int column, int[] array, int n)
    {
        if (array[(row + n * (row - 1)) + (column - row)] == 1)
        {
            return true;
        }
        return false;
    }

    static bool isFull(int row, int column, int[] array, int n)
    {
        if (array[(row + n * (row - 1)) + (column - row)] == 2)
        {
            return true;
        }
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

        int size = n * n + 2;
        int[] linerMatrix = new int[size];

        linerMatrix[0] = 2;
        linerMatrix[size - 1] = 1;
        for (int i = 0; i < size; i++)
        {
            Console.Write(linerMatrix[i] + " ");
        }


        Console.WriteLine();


        while (true)
        {
            try
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
                    linerMatrix[(row + n * (row - 1)) + (column - row)] = 1;
                    for (int i = 0; i < size; i++)
                    {
                        Console.Write(linerMatrix[i] + " ");
                    }

                    matrix[row, column] = 1;
                }

                if (num == 2)
                {
                    Console.WriteLine("Enter number of matrix row and column: ");
                    Console.Write("Row: ");
                    byte row = Convert.ToByte(Console.ReadLine());
                    Console.Write("Column: ");
                    byte column = Convert.ToByte(Console.ReadLine());

                    Console.WriteLine(isOpen(row, column, linerMatrix, n));
                }

                if (num == 3)
                {
                    Console.WriteLine("Enter number of matrix row and column: ");
                    Console.Write("Row: ");
                    byte row = Convert.ToByte(Console.ReadLine());
                    Console.Write("Column: ");
                    byte column = Convert.ToByte(Console.ReadLine());

                    Console.WriteLine(isFull(row, column, linerMatrix, n));
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
            catch
            {
                Console.WriteLine("Input Error");
            }
        }
        Console.WriteLine("end");
    }


}
