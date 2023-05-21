using System;
using System.Drawing;
using System.Threading;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            IVessel sailingVessel = new SailingVessel();
            IVessel submarine = new Submarine();

            ConsoleInterface menu = new ConsoleInterface();

            bool isSalingVesselPrepared = false;
            bool isSubmarinePrepared = false;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose your vessel:");
                menu.Reset();
                Console.WriteLine( menu.SetMenuItem("1. Sailing Vessel") );
                Console.WriteLine( menu.SetMenuItem("2. Submarine") );
                
                int mainMenuNumber = menu.GetCheckedInput();

                switch (mainMenuNumber)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Your have chosen Sailing Vessel!:");

                        menu.Reset();

                        if (isSalingVesselPrepared) Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(menu.SetMenuItem("1. Prepare to move"));
                        Console.ResetColor();
                        Console.WriteLine(menu.SetMenuItem("2. Move"));

                        int selingVesselMenuNumber = menu.GetCheckedInput();

                        if (selingVesselMenuNumber == 1)
                        {
                            isSalingVesselPrepared = true;
                            Console.Clear();
                            Console.WriteLine(sailingVessel.PrepareToMovement());
                            Thread.Sleep(3000);
                        }

                        if (!isSalingVesselPrepared)
                        {
                            Console.Clear();
                            Console.WriteLine("You are not prepare!");
                            Thread.Sleep(3000);
                            break;
                        }

                        if (selingVesselMenuNumber == 2)
                        {
                            Console.Clear();
                            Console.WriteLine(sailingVessel.Move());
                            Thread.Sleep(3000);
                        }

                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Your have chosen Submarine!:");

                        menu.Reset();

                        if (isSubmarinePrepared) Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(menu.SetMenuItem("1. Prepare to move"));
                        Console.ResetColor();
                        Console.WriteLine(menu.SetMenuItem("2. Move"));

                        int submarineMainMenuNumber = menu.GetCheckedInput();

                        if (submarineMainMenuNumber == 1)
                        {
                            isSubmarinePrepared = true;
                            Console.Clear();
                            Console.WriteLine(submarine.PrepareToMovement());
                            Thread.Sleep(3000);
                        }

                        if (!isSubmarinePrepared)
                        {
                            Console.Clear();
                            Console.WriteLine("You are not prepare!");
                            Thread.Sleep(3000);
                            break;
                        }

                        if (submarineMainMenuNumber == 2)
                        {
                            Console.Clear();
                            Console.WriteLine(submarine.Move());
                            Thread.Sleep(3000);
                        }

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

    abstract class Vessel
    {
        abstract public string PrepareToMovement();

        abstract public string Move();
    }

    class SailingVessel : IVessel
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

        private bool IsInputValid(string input)
        {
            int number;
            bool isNumber = int.TryParse(input, out number);

            if (!isNumber) return false;

            if (number < 0 || number > _menuLength) return false;

            return true;
        }

        public int GetCheckedInput()
        {
            while (true)
            {
                string input = Console.ReadLine().Replace(" ", "");

                if (!IsInputValid(input)) continue;

                return Int32.Parse(input);
            }
        }
    }
}
