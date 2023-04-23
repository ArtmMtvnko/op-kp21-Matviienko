using System;
using System.ComponentModel;
using System.Data.Common;
using System.Globalization;
using System.Numerics;
using System.Xml;
class Percolate
{
    // метод ініціалізації масиву
    static void init(int n, int[] array)
    {
        for (int i = 0; i < n * n + 2; i++)
        {
            array[i] = i;
        }
    }

    // метод юніон, який зв'язує компоненти
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

    // метод find, який знаходить корінь дерева (графу)
    static int find(int x, int[] array)
    {
        int res = array[x];
        while (res != array[res])
        {
            res = array[res];
        }

        return res;
    }

    // метод open відкриває корімку та відразу шукає чи є відкриті комірки навколо,
    // якщо так, то робить число від'ємник (якби виділяя це число серед інших)
    // та зв'язує їх за допомогої методу union()
    static void open(int row, int column, int[] array, int n)
    {
        array[n * (row - 1) + column] *= (-1);
        if (column != n)
        {
            if (array[n * (row - 1) + column + 1] <= 0)
            {
                union(n * (row - 1) + column, n * (row - 1) + column + 1, array);
            }
        }
        if (column != 1)
        {
            if (array[n * (row - 1) + column - 1] <= 0)
            {
                union(n * (row - 1) + column, n * (row - 1) + column - 1, array);
            }
        }
        if (row != n)
        {
            if (array[n * (row - 1) + column + n] <= 0)
            {
                union(n * (row - 1) + column, n * (row - 1) + column + n, array);
            }
        }
        if (row != 1)
        {
            if (array[n * (row - 1) + column - n] <= 0)
            {
                union(n * (row - 1) + column, n * (row - 1) + column - n, array);
            }
        }
    }
    // метод перевіряє чи відкрита комірка, шляхом перевірки числа на від'ємний знак
    static bool isOpen(int row, int column, int[] array, int n)
    {
        if (array[n * (row - 1) + column] <= 0)
        {
            return true;
        }
        return false;
    }

    // метод перевіряє чи є струм у комірці, шляхом перевірки числа 0
    static bool isFull(int row, int column, int[] array, int n)
    {
        if (array[n * (row - 1) + column] == 0)
        {
            return true;
        }
        return false;
    }
    // виводить кількість відкритих комірок, шляхом перевірки чи є число мене або дорівнює 0
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
    // метод "подає напругу", шляхом перевірки чи зв'язані компоненти з "джерелом" (arr[0])
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
    // якщо є струм у останніх елементах матриці, то система перколює - проводить струм
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

    // метод виводить одновимірний масив як матрицю,
    // та виводить 0, там де корірка закрита
    // виводить 1, де вона відкрита, але по ній не протікає струм
    // виводить 2, якщо у комірці протікає струм
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
    // метод виводить одновимірний массив
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
        // UNIT TESTS
        // Console.WriteLine("Test init(): " + TestInit());
        // Console.WriteLine("Test numberOfOpenSites(): " + TestNumberOfOpenSites());
        // Console.WriteLine("Test isPercolates(): " + TestIsPercolates());
        // Console.WriteLine("Test open(): " + TestOpen());
        // Console.WriteLine("Test isFull(): " + TestIsFull());
        // Console.WriteLine("Test union(): " + TestUnion());


        // вводимо розмір матриці, та перевіряємо на коректність введення данних
        int n;
        while (true)
        {
            try
            {
                Console.Write("Enter size of matrix: ");
                n = Math.Abs(Convert.ToInt32(Console.ReadLine()));
                break;
            }
            catch
            {
                Console.WriteLine("Input Error");
            }
        }
        // створюємо масив, та ініціалізуємо його
        int[] linerMatrix = new int[n * n + 2];

        init(n, linerMatrix);

        Console.WriteLine();

        // виводимо меню набору дій для користувача, та також перевіряємо на коректність данних
        // номер числа, який введе користувач відповідає виклику відповідного методу
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
                Console.WriteLine("6 - check does the system percolates?");
                Console.WriteLine("7 - reset");
                Console.WriteLine("8 - exit");

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
                    init(n, linerMatrix);
                }

                if (num == 8)
                {
                    break;
                }
            }
            catch
            {
                Console.WriteLine("Input Error");
            }
        }
        Console.WriteLine("End");
    }

    // ======== UNIT TESTS ========= UNIT TESTS ========= UNIT TESTS ========= UNIT TESTS =========

    static bool TestInit()
    {
        int[] testArr1 = new int[27];

        int expected1 = 0;  // i = 0
        int expected2 = 1;  // i = 1
        int expected3 = 2;  // i = 2
        int expected4 = 3;  // i = 3
        int expected5 = 4;  // i = 4
        int expected6 = 5;  // i = 5

        init(5, testArr1);

        if (testArr1[0] != expected1)
        {
            return false;
        }
        if (testArr1[1] != expected2)
        {
            return false;
        }
        if (testArr1[2] != expected3)
        {
            return false;
        }
        if (testArr1[3] != expected4)
        {
            return false;
        }
        if (testArr1[4] != expected5)
        {
            return false;
        }
        if (testArr1[5] != expected6)
        {
            return false;
        }

        return true;
    }
    static bool TestOpen() // Test isOpen() also
    {
        int[] testArr = new int[27]; // n = 5
        init(5, testArr);

        open(2, 2, testArr, 5);
        open(4, 4, testArr, 5);
        open(2, 3, testArr, 5);
        open(1, 1, testArr, 5);

        isOpen(2, 2, testArr, 5);
        isOpen(4, 4, testArr, 5);
        isOpen(2, 1, testArr, 5);
        isOpen(3, 3, testArr, 5);

        bool expected1 = true;
        bool expected2 = true;
        bool expected3 = false;
        bool expected4 = false;
        if (isOpen(2, 2, testArr, 5) != expected1)
        {
            return false;
        }
        if (isOpen(4, 4, testArr, 5) != expected2)
        {
            return false;
        }
        if (isOpen(2, 1, testArr, 5) != expected3)
        {
            return false;
        }
        if (isOpen(3, 3, testArr, 5) != expected4)
        {
            return false;
        }
        return true;
    }

    static bool TestUnion()
    {
        int[] testArr = new int[27]; // n = 5
        init(5, testArr);

        union(10, 15, testArr); // 15
        union(7, 10, testArr);  // 10
        union(5, 6, testArr);   // 6
        union(19, 20, testArr); // 20

        int expected1 = 15;
        int expected2 = 15;
        int expected3 = 6;
        int expected4 = 20;

        if (expected1 != testArr[15])
        {
            return false;
        }
        if (expected2 != testArr[10])
        {
            return false;
        }
        if (expected3 != testArr[6])
        {
            return false;
        }
        if (expected4 != testArr[20])
        {
            return false;
        }

        return true;
    }

    static bool TestIsFull()
    {
        int[] testArr = new int[27]; // n = 5
        init(5, testArr);

        open(1, 1, testArr, 5);
        open(2, 1, testArr, 5);
        open(3, 1, testArr, 5);
        open(4, 1, testArr, 5);
        open(5, 1, testArr, 5);

        percolates(5, testArr);

        bool expected1 = true;
        bool expected2 = true;
        bool expected3 = true;
        bool expected4 = false;
        bool expected5 = false;
        bool expected6 = false;

        bool action1 = isFull(1, 1, testArr, 5);
        bool action2 = isFull(3, 1, testArr, 5);
        bool action3 = isFull(5, 1, testArr, 5);
        bool action4 = isFull(1, 2, testArr, 5);
        bool action5 = isFull(2, 3, testArr, 5);
        bool action6 = isFull(4, 4, testArr, 5);

        if (action1 != expected1)
        {
            return false;
        }
        if (action2 != expected2)
        {
            return false;
        }
        if (action3 != expected3)
        {
            return false;
        }
        if (action4 != expected4)
        {
            return false;
        }
        if (action5 != expected5)
        {
            return false;
        }
        if (action6 != expected6)
        {
            return false;
        }

        return true;
    }
    static bool TestNumberOfOpenSites()
    {
        int[] testArr = new int[27]; // n = 5
        init(5, testArr);

        int expected = 5;

        open(1, 1, testArr, 5);
        open(2, 2, testArr, 5);
        open(2, 3, testArr, 5);
        open(3, 3, testArr, 5);
        open(3, 4, testArr, 5);
        Console.WriteLine(numberOfOpenSites(5, testArr));

        if (numberOfOpenSites(5, testArr) != expected)
        {
            return false;
        }
        return true;
    }
    static bool TestIsPercolates() // test percolates() also
    {
        int[] testArr = new int[27]; // n = 5
        init(5, testArr);

        open(1, 1, testArr, 5);
        open(2, 1, testArr, 5);
        open(3, 1, testArr, 5);
        open(4, 1, testArr, 5);
        open(5, 1, testArr, 5);

        percolates(5, testArr);

        if (isPercolates(5, testArr))
        {
            return true;
        }
        return false;
    }
    static bool TestPrint() // result on screen
    {
        return false;
    }

    // ======== UNIT TESTS END ========= UNIT TESTS END ========= UNIT TESTS END =========
}
