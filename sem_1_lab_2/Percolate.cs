using System;
using System.ComponentModel;
using System.Globalization;
using System.Numerics;
using System.Xml;
class Percolation
{
    static void init(int n)
    {

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
        int[,] matrix = new int[n+1, n+1];    

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                matrix[i, j] = 0;
            }
        }

        print(matrix, n);
    }


}
