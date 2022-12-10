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
        int componentX = array[x];
        int componentY = array[y];
        if (componentX == componentY)
        {
            return;
        }
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == componentX)
            {
                array[i] = componentY;
            }
        }
    }

    static void open(int row, int column)
    {

    }

    static bool isOpen(int row, int column, int[] array, int n)
    {
        if (array[n * (row - 1) + column] == 1)
        {
            return true;
        }
        return false;
    }

    static bool isFull(int row, int column, int[] array, int n)
    {
        if (array[n * (row - 1) + column] == 2)
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

    static void print(int n, int[] array)
    {
        for (int i = 1; i <= n * n; i++)
        {
            if (array[i] == i)
            {
                Console.Write(0 + " ");
            }
            else
            {
                Console.Write(1 + " ");
            }

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

        //int size = n * n + 2;
        int[] linerMatrix = new int[n * n + 2];

        init(n, linerMatrix);
        for (int i = 0; i < n; i++)
        {
            union(0, n, linerMatrix);
        }

        union(5, 10, linerMatrix);
        union(3, 4, linerMatrix);
        union(4, 7, linerMatrix);
        union(11, 14, linerMatrix);
        union(7, 14, linerMatrix);
        union(11, 10, linerMatrix);
        union(8, 15, linerMatrix);
        union(10, 15, linerMatrix);

        for (int i = 0; i < n; i++)
        {
            if (linerMatrix[0] == n * n - i)
            {
                union(n * n - i, n * n + 1, linerMatrix);
            }
        }


        Console.WriteLine();


        while (true)
        {
            try
            {
                print(n, linerMatrix);
                test(n, linerMatrix);

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
                    linerMatrix[n * (row - 1) + column] = 1;
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
