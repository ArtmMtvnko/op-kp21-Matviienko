using System;
using System.Drawing;
using System.Threading;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            IVessel a = new SailingVesse();
            IVessel b = new Submarine();

            ConsoleInterface menu = new ConsoleInterface();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose your vessel:");
                menu.Reset();
                Console.WriteLine(menu.SetMenuItem("1. Sailing Vessel"));
                Console.WriteLine(menu.SetMenuItem("2. Submarine"));

                string mainMenuInput = Console.ReadLine();

                if (!menu.IsInputValid(mainMenuInput)) continue;

                int mainMenuNumber = Int32.Parse(mainMenuInput);

                switch (mainMenuNumber)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Your have chosen Sailing Vessel!:");
                        menu.Reset();
                        Console.WriteLine(menu.SetMenuItem("1. Prepare to move"));
                        Console.WriteLine(menu.SetMenuItem("2. Move"));

                        string SelingVesselInput = Console.ReadLine();

                        if (!menu.IsInputValid(SelingVesselInput)) continue;

                        int SelingVesselMenuNamber = Int32.Parse(SelingVesselInput);

                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Your have chosen Submarine!:");
                        menu.Reset();
                        Console.WriteLine(menu.SetMenuItem("1. Prepare to move"));
                        Console.WriteLine(menu.SetMenuItem("2. Move"));

                        string SubmarineInput = Console.ReadLine();

                        if (!menu.IsInputValid(SubmarineInput)) continue;

                        int SubmarineMenuNamber = Int32.Parse(SubmarineInput);
                        break;
                }
            }
        }
    }

    interface IVessel
    {
        string PrepareToMovement();

        string Move();
    }

    class SailingVesse : IVessel
    {
        public string PrepareToMovement()
        {
            return "Open the sails! Weigh anchor";
        }

        public string Move()
        {
            return "Straight ahead! Wind on the other side!";
        }
    }

    class Submarine : IVessel
    {
        public string PrepareToMovement()
        {
            return "Сlose all hatches, sinking!";
        }

        public string Move()
        {
            return "Straight ahead! Follow of the echo sounder";
        }
    }

    class ConsoleInterface
    {
        private int _menuLength;

        public ConsoleInterface()
        {
            _menuLength = 0;
        }

        public void Reset()
        {
            _menuLength = 0;
        }

        public string SetMenuItem(string message)
        {
            _menuLength++;
            return message;
        }

        public bool IsInputValid(string input)
        {
            int number;
            bool isNumber = int.TryParse(input, out number);

            if (!isNumber) return isNumber;

            if (number < 0 || number > _menuLength) return false;

            return isNumber;
        }
    }
}
