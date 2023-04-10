using System;
using System.Numerics;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector a = new Vector(1,1,2,3,4,1,1,2);

            Console.WriteLine((-a).ToString());
        }
    }

    class Vector
    {
        private int[] _coordinates;
        public Vector(params int[] numbers)
        {
            _coordinates = numbers;
        }

        public static Vector operator -(Vector vector)
        {
            int[] numbers = new int[vector._coordinates.Length];

            for (int i = 0; i < vector._coordinates.Length; i++)
            {
                numbers[i] = (-vector._coordinates[i]);
            }

            return new Vector(numbers);
        }
        /*
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return a + (-b);
        }

        public static int operator *(Vector a, Vector b)
        {
            return ( a.X * b.X ) + ( a.Y * b.Y );
        }

        public static int operator /(Vector a, Vector b)
        {
            return (a.X * b.X) + (a.Y * b.Y);
        }
        */

        public override string ToString()
        {
            string output = "";
            output += _coordinates[0];
            for (int i = 1; i < _coordinates.Length; i++)
            {
                output += "," + _coordinates[i];
            }

            return String.Format("Vector: ( {0} )", output);
        }
    }
}