using System;
class World
{
    static void Main(string[] args)
    {
        int a = 0;
        int b = 0;
        int c = 0;
        int d = 0;
        Console.Write("Enter a: ");
        a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter b: ");
        b = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter c: ");
        c = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter d: ");
        d = Convert.ToInt32(Console.ReadLine());

        if (a == b)
        {
            Console.WriteLine("You have same numbers");
        }
        if (a == c)
        {
            Console.WriteLine("You have same numbers");
        }
        if (a == d)
        {
            Console.WriteLine("You have same numbers");
        }
        if (b == c)
        {
            Console.WriteLine("You have same numbers");
        }
        if (b == d)
        {
            Console.WriteLine("You have same numbers");
        }
        if (c == d)
        {
            Console.WriteLine("You have same numbers");
        }




        if (a < b)
        {
            if (a < c)
            {
                if (a < d)
                {
                    Console.WriteLine("Minimal value is a: " + a);
                } 
                else
                {
                    Console.WriteLine("Minimal value is d: " + d);
                }
            }
            else
            {
                if (c < d)
                {
                    Console.WriteLine("Minimal value is c: " + c);
                }
                else
                {
                    Console.WriteLine("Minimal value is d: " + d);
                }
            }
        }
        else
        {
            if (b < c)
            {
                if (b < d) 
                {
                    Console.WriteLine("Minimal value is b: " + b);
                }
                else
                {
                    Console.WriteLine("Minimal value is d: " + d);
                }
            }
            else
            {
                if (c < d)
                {
                    Console.WriteLine("Minimal value is c: " + c);
                }
                else
                {
                    Console.WriteLine("Minimal value is d: " + d);
                }
            }
        }
    }
}
