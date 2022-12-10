using System;
using System.ComponentModel;
using System.Data.Common;
using System.Globalization;
using System.Numerics;
using System.Xml;
class Percolate
{
    static void init(int n, int[] array)
    {
        for (int i = 0; i < n * n + 2; i++)
        {
            array[i] = i;
        }
    }

    static void union(int x, int y, int[] array)
    {
        int componentX = array[x]; // -2
        int componentY = array[y]; // 0
        if (componentX == componentY)
        {
            return;
        }
        for (int i = 0; i <= array.Length; i++)
        {
            if (array[i] == componentX)
            {
                array[i] = componentY;
            }
        }
    }

    static int find(int x, int[] array)
    {
        int res = array[x];
        while (res != array[res])
        {
            res = array[res];
        }

        return res;
    }

    static void open(int row, int column, int[] array, int n)
    {
        array[n * (row - 1) + column] *= (-1);
        if (column != n)
        {
            if (array[n * (row - 1) + column + 1] < 0)
            {
                union(n * (row - 1) + column, n * (row - 1) + column + 1, array);
            }
        }
        if (column != 1)
        {
            if (array[n * (row - 1) + column - 1] < 0)
            {
                union(n * (row - 1) + column, n * (row - 1) + column - 1, array);
            }
        }
        if (row != n)
        {
            if (array[n * (row - 1) + column + n] < 0)
            {
                union(n * (row - 1) + column, n * (row - 1) + column + n, array);
            }
        }
        if (array[n * (row - 1) + column - n] < 0)
        {
            union(n * (row - 1) + column, n * (row - 1) + column - n, array);
        }
    }

    static bool isOpen(int row, int column, int[] array, int n)
    {
        if (array[n * (row - 1) + column] < 0)
        {
            return true;
        }
        return false;
    }

    static bool isFull(int row, int column, int[] array, int n)
    {
        if (array[n * (row - 1) + column] == 0)
        {
            return true;
        }
        return false;
    }

    static int numberOfOpenSites(int n, int[] array)
    {
        int counter = 0;
        for (int i = 1; i <= n * n; i++)
        {
            if (array[i] <= 0)
            {
                counter++;
            }
        }
        return counter;
    }

    static void percolates(int n, int[] array)
    {
        for (int i = 1; i <= n; i++)
        {
            if (array[i] < 0)
            {
                union(i, 0, array);
            }
        }
    }

    static bool isPercolates(int n, int[] array)
    {
        for (int i = n * n - n + 1; i <= n * n; i++)
        {
            if (array[i] == 0)
            {
                return true;
            }
        }
        return false;
    }


    static void print(int n, int[] array)
    {
        for (int i = 1; i <= n * n; i++)
        {
            if (array[i] == i)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(0 + " ");
            }
            if (array[i] < 0)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(1 + " ");
            }
            if (array[i] == 0)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(2 + " ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            if (i % n == 0)
            {
                Console.WriteLine();
            }
        }
    }

    static void test(int n, int[] array)
    {
        for (int i = 0; i < n * n + 2; i++)
        {
            Console.Write(array[i] + " ");
        }
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
        int[] linerMatrix = new int[n * n + 2];

        init(n, linerMatrix);

        Console.WriteLine();


        while (true)
        {
            try
            {
                print(n, linerMatrix);
                // Console.WriteLine("Linear array: ");
                // test(n, linerMatrix);
                Console.WriteLine();

                Console.WriteLine("Choose the action with matrix: ");
                Console.WriteLine("1 - open site");
                Console.WriteLine("2 - check is site open?");
                Console.WriteLine("3 - check is the site full?");
                Console.WriteLine("4 - output numbers of open sites");
                Console.WriteLine("5 - give a voltage");
                Console.WriteLine("6 - check does the system percolates");
                Console.WriteLine("7 - exit");

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

                    open(row, column, linerMatrix, n);
                }

                if (num == 2)
                {
                    Console.WriteLine("Enter number of matrix row and column: ");
                    Console.Write("Row: ");
                    byte row = Convert.ToByte(Console.ReadLine());
                    Console.Write("Column: ");
                    byte column = Convert.ToByte(Console.ReadLine());

                    Console.WriteLine("Is the site open?: " + isOpen(row, column, linerMatrix, n));
                }

                if (num == 3)
                {
                    Console.WriteLine("Enter number of matrix row and column: ");
                    Console.Write("Row: ");
                    byte row = Convert.ToByte(Console.ReadLine());
                    Console.Write("Column: ");
                    byte column = Convert.ToByte(Console.ReadLine());

                    Console.WriteLine("Is the site full?: " + isFull(row, column, linerMatrix, n));
                }

                if (num == 4)
                {
                    Console.WriteLine("Number of open sites = " + numberOfOpenSites(n, linerMatrix));
                }

                if (num == 5)
                {
                    percolates(n, linerMatrix);
                }

                if (num == 6)
                {
                    Console.WriteLine("Does system percolates?: " + isPercolates(n, linerMatrix));
                }

                if (num == 7)
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
