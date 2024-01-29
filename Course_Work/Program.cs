using System;
using System.Drawing;
using System.Runtime.ConstrainedExecution;

namespace Course_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleInterface<string> menu = new ConsoleInterface<string>();

            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("Whitch type of car you want?\n");
                menu.AddItem("1. Old cars (retro) 1950-1970");
                menu.AddItem("2. New cars 2010-now");

                int input = menu.GetCheckedInput();
                bool isOldCar = false;
                bool isNewCar = false;

                OldCarList oldCarList = new OldCarList();
                NewCarList newCarList = new NewCarList();

                switch (input)
                {
                    case 1:
                        oldCarList.Init(@"D:\Microsoft Visual Studio\Projects\Course_Work\Course_Work\Old-Cars.csv");
                        isOldCar = true;
                        Console.Clear();
                        break;
                    case 2:
                        newCarList.Init(@"D:\Microsoft Visual Studio\Projects\Course_Work\Course_Work\New-Cars.csv");
                        isNewCar = true;
                        Console.Clear();
                        break;
                }

                menu.Reset();

                menu.AddItem("1. Show all list");
                menu.AddItem("2. Seletc filters");

                input = menu.GetCheckedInput();
                bool isEnd = false;

                switch (input)
                {
                    case 1:
                        isEnd = true;
                        if (isNewCar)
                            newCarList.ShowList();
                        Console.WriteLine("\n");
                        if (isOldCar)
                            oldCarList.ShowList();
                        Console.WriteLine("\n");
                        Console.ReadLine();
                        break;
                    case 2:
                        break;
                }

                if (isEnd) continue;

                menu.Reset();

                string type = isOldCar ? "Old car" : "New car";
                double budgetLow;
                double budgetHigh;
                int conditionLow;
                int conditionHigh;
                string transmission;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Type: {type}\n");
                Console.ResetColor();

                Console.WriteLine("Select price range\n");
                menu.AddItem("0. Custom price");
                menu.AddItem("1. Up to $5.000");
                menu.AddItem("2. From $5.000 up to $20.000");
                menu.AddItem("3. From $20.000 up to $50.000");
                menu.AddItem("4. From $50.000 up to $100.000");
                menu.AddItem("5. From $100.000 up to $200.000");
                menu.AddItem("6. From $200.000 up to $500.000");
                menu.AddItem("7. From $500.000 up to $1.000.000");
                menu.AddItem("8. From $1.000.000");

                input = menu.GetCheckedInput();


                switch (input)
                {
                    case 0:
                        Console.WriteLine("Enter lower price:");
                        budgetLow = menu.GetLowerValue();
                        Console.WriteLine("Enter higher price:");
                        budgetHigh = menu.GetHigherValue(budgetLow);
                        break;
                    case 1:
                        budgetLow = 0;
                        budgetHigh = 5000;
                        break;
                    case 2:
                        budgetLow = 5000;
                        budgetHigh = 20000;
                        break;
                    case 3:
                        budgetLow = 20000;
                        budgetHigh = 50000;
                        break;
                    case 4:
                        budgetLow = 50000;
                        budgetHigh = 100000;
                        break;
                    case 5:
                        budgetLow = 100000;
                        budgetHigh = 200000;
                        break;
                    case 6:
                        budgetLow = 200000;
                        budgetHigh = 500000;
                        break;
                    case 7:
                        budgetLow = 500000;
                        budgetHigh = 1000000;
                        break;
                    case 8:
                        budgetLow = 10000000;
                        budgetHigh = double.PositiveInfinity;
                        break;
                    default:
                        budgetLow = 0;
                        budgetHigh = double.PositiveInfinity;
                        break;
                }

                menu.Reset();

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Type: {type}");
                Console.WriteLine($"Price: {budgetLow}-{budgetHigh}\n");
                Console.ResetColor();
                Console.WriteLine("Enter wanted condition from 1 up to 10\n");
                menu.AddItem("0. Custom condition");
                menu.AddItem("1. (1-3) the worst condition (for parts)");
                menu.AddItem("2. (4-7) mediocre condition (replace some details)");
                menu.AddItem("3. (8-10) good condition (visual defect)");

                input = menu.GetCheckedInput();

                switch (input)
                {
                    case 0:
                        Console.WriteLine("Enter lower condition:");
                        conditionLow = menu.GetLowerValueInt(10);
                        Console.WriteLine("Enter higher condition:");
                        conditionHigh = menu.GetHigherValueInt(conditionLow, 10);
                        break;
                    case 1:
                        conditionLow = 1;
                        conditionHigh = 3;
                        break;
                    case 2:
                        conditionLow = 4;
                        conditionHigh = 7;
                        break;
                    case 3:
                        conditionLow = 8;
                        conditionHigh = 10;
                        break;
                    default:
                        conditionLow = 1;
                        conditionHigh = 10;
                        break;
                }

                menu.Reset();

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Type: {type}");
                Console.WriteLine($"Price: {budgetLow}-{budgetHigh}");
                Console.WriteLine($"Condition: {conditionLow}-{conditionHigh}\n");
                Console.ResetColor();
                Console.WriteLine("Select whitch type of transmission you want\n");
                menu.AddItem("0. All Transmissions");
                menu.AddItem("1. Manual");
                menu.AddItem("2. Automatic");
                menu.AddItem("3. Robotic");
                menu.AddItem("4. None");

                input = menu.GetCheckedInput();

                switch (input)
                {
                    case 0:
                        transmission = null;
                        break;
                    case 1:
                        transmission = "Manual";
                        break;
                    case 2:
                        transmission = "Automatic";
                        break;
                    case 3:
                        transmission = "Robotic";
                        break;
                    case 4:
                        transmission = "None";
                        break;
                    default:
                        transmission = "Automatic";
                        break;
                }

                Car car = null;

                if (transmission == null && isOldCar)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Type: {type}");
                    Console.WriteLine($"Price: {budgetLow}-{budgetHigh}");
                    Console.WriteLine($"Condition: {conditionLow}-{conditionHigh}");
                    Console.WriteLine($"Transmission: All\n");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    oldCarList.Sort(budgetLow, budgetHigh, conditionLow, conditionHigh, "Manual");
                    oldCarList.Sort(budgetLow, budgetHigh, conditionLow, conditionHigh, "Automatic");

                    if (oldCarList.GetLength() == 0)
                    {
                        Console.WriteLine("Sorry, we don't have cars with this feature :(");
                        Thread.Sleep(3500);
                        continue;
                    }

                    oldCarList.ShowProposed();

                    Console.ResetColor();
                    Console.WriteLine("\n");

                    car = oldCarList.GetProposed();
                }

                if (transmission == null && isNewCar)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Type: {type}");
                    Console.WriteLine($"Price: {budgetLow}-{budgetHigh}");
                    Console.WriteLine($"Condition: {conditionLow}-{conditionHigh}");
                    Console.WriteLine($"Transmission: All\n");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    newCarList.Sort(budgetLow, budgetHigh, conditionLow, conditionHigh, "Manual");
                    newCarList.Sort(budgetLow, budgetHigh, conditionLow, conditionHigh, "Automatic");
                    newCarList.Sort(budgetLow, budgetHigh, conditionLow, conditionHigh, "Robotic");
                    newCarList.Sort(budgetLow, budgetHigh, conditionLow, conditionHigh, "None");

                    if (newCarList.GetLength() == 0)
                    {
                        Console.WriteLine("Sorry, we don't have cars with this feature :(");
                        Thread.Sleep(3500);
                        continue;
                    }

                    newCarList.ShowProposed();

                    Console.ResetColor();
                    Console.WriteLine("\n");

                    car = newCarList.GetProposed();
                }


                if (isOldCar && transmission != null)
                {
                    oldCarList.Sort(budgetLow, budgetHigh, conditionLow, conditionHigh, transmission);

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Type: {type}");
                    Console.WriteLine($"Price: {budgetLow}-{budgetHigh}");
                    Console.WriteLine($"Condition: {conditionLow}-{conditionHigh}");
                    Console.WriteLine($"Transmission: {transmission}\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    if (oldCarList.GetLength() == 0)
                    {
                        Console.WriteLine("Sorry, we don't have cars with this feature :(");
                        Thread.Sleep(3500);
                        continue;
                    }

                    oldCarList.ShowProposed();

                    Console.ResetColor();
                    Console.WriteLine("\n");

                    car = oldCarList.GetProposed();
                }

                if (isNewCar && transmission != null)
                {
                    newCarList.Sort(budgetLow, budgetHigh, conditionLow, conditionHigh, transmission);

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Type: {type}");
                    Console.WriteLine($"Price: {budgetLow}-{budgetHigh}");
                    Console.WriteLine($"Condition: {conditionLow}-{conditionHigh}");
                    Console.WriteLine($"Transmission: {transmission}\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    if (newCarList.GetLength() == 0)
                    {
                        Console.WriteLine("Sorry, we don't have cars with this feature :(");
                        Thread.Sleep(3500);
                        continue;
                    }

                    newCarList.ShowProposed();

                    Console.ResetColor();
                    Console.WriteLine("\n");

                    car = newCarList.GetProposed();
                }

                var buyer = new Buyer();

                Console.WriteLine("Enter your Name:");
                buyer.Name = Console.ReadLine().Replace(" ", "");

                var address = new Address();

                Console.WriteLine("Enter the city where you want to deliver: ");
                address.City = Console.ReadLine().Replace(" ", "");

                Console.WriteLine("Enter the street where you want to deliver: ");
                address.Street = Console.ReadLine().Replace(" ", "");

                Console.WriteLine("Enter the house-number where you want to deliver: ");
                address.HouseNumber = Console.ReadLine().Replace(" ", "");

                address.PostalCode = new Random().Next(10000, 100000);

                var order = new Order(buyer.Name, address);

                order.Car = car;

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Clear();
                Console.WriteLine("Your order:\n");
                Console.WriteLine(order.MakeOrder());
                Console.ResetColor();

                Console.WriteLine();
                Console.ReadLine();
            } // While (true)
        }
    }

    abstract class Car
    {
        abstract public string ToString();
    }

    class OldCar : Car
    {
        public string _model;
        public int _year;
        public string _brand;
        public int _power;
        public int _maxSpeed;
        public string _transmission;
        public double _price;
        public int _technicalCondition;

        public OldCar(string csvLine)
        {
            string[] values = csvLine.Split(',');

            _brand = values[0];
            _model = values[1];
            _year = int.Parse(values[2]);
            _price = double.Parse(values[3]);
            _technicalCondition = int.Parse(values[4]);
            _power = int.Parse(values[5]);
            _maxSpeed = int.Parse(values[6]);
            _transmission = values[7];
        }

        public override string ToString()
        {
            return $"{_brand}, {_model}, {_year}, ${_price}, {_technicalCondition}/10, {_power} h.p., {_maxSpeed} km/h, {_transmission}";
        }
    }

    class NewCar : Car
    {
        public string _model;
        public int _year;
        public string _brand;
        public int _power;
        public int _maxSpeed;
        public string _transmission;
        public double _price;
        public int _technicalCondition;

        public NewCar(string csvLine)
        {
            string[] values = csvLine.Split(',');

            _brand = values[0];
            _model = values[1];
            _year = int.Parse(values[2]);
            _price = double.Parse(values[3]);
            _technicalCondition = int.Parse(values[4]);
            _power = int.Parse(values[5]);
            _maxSpeed = int.Parse(values[6]);
            _transmission = values[7];
        }

        public override string ToString()
        {
            return $"{_brand}, {_model}, {_year}, ${_price}, {_technicalCondition}/10, {_power} h.p., {_maxSpeed} km/h, {_transmission}";
        }
    }



    interface ICarList
    {
        void Init(string path);

        void Sort(double budgetLow, double budgetHigh, int conditionLow, int conditionHigh, string transmission);

        void ShowList();

        void ShowProposed();

        Car GetProposed();
    }

    class OldCarList : ICarList
    {
        private List<Car> _cars;
        private List<Car> _sortedCars;
        public OldCarList()
        {
            _cars = new List<Car>();
            _sortedCars = new List<Car>();
        }

        public int GetLength()
        {
            return _sortedCars.Count;
        }

        public void Init(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    Car oldCar = new OldCar(line);
                    _cars.Add(oldCar);
                }
            }
        }
        public void ShowList()
        {
            foreach (var car in _cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        public void ShowProposed()
        {
            int _index = 1;
            foreach (var car in _sortedCars)
            {
                Console.WriteLine($"{_index}. {car.ToString()}");
                _index++;
            }
        }

        public Car GetProposed()
        {
            Console.WriteLine("Enter number of car you want to buy:");

            int num;

            while (true)
            {
                try
                {
                    string input = Console.ReadLine().Replace(" ", "");

                    bool isPassed = int.TryParse(input, out num);

                    if (isPassed && num <= _sortedCars.Count && num > 0)
                        break;

                    Console.WriteLine("Wrong Input");

                    continue;
                }
                catch
                {
                    Console.WriteLine("Wrong Input");
                }
            }
            return _sortedCars[num - 1];
        }

        public void Sort(double budgetLow, double budgetHigh, int conditionLow, int conditionHigh, string transmission)
        {
            foreach (OldCar car in _cars)
            {
                if (car._price > budgetLow && car._price <= budgetHigh
                    && car._technicalCondition >= conditionLow
                    && car._technicalCondition <= conditionHigh
                    && car._transmission == transmission)
                    _sortedCars.Add(car);
            }
        }
    }

    class NewCarList : ICarList
    {
        private List<Car> _cars;
        private List<Car> _sortedCars;
        private List<Car> _proposed;
        public NewCarList()
        {
            _cars = new List<Car>();
            _sortedCars = new List<Car>();
            _proposed = new List<Car>();
        }

        public int GetLength()
        {
            return _sortedCars.Count;
        }

        public void Init(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    Car newCar = new NewCar(line);
                    _cars.Add(newCar);
                }
            }
        }

        public void ShowList()
        {
            foreach (var car in _cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        public void ShowProposed()
        {
            int _index = 1;
            foreach (var car in _sortedCars)
            {
                Console.WriteLine($"{_index}. {car.ToString()}");
                _index++;
            }
        }

        public Car GetProposed()
        {
            Console.WriteLine("Enter number of car you want to buy:");

            int num;

            while (true)
            {
                try
                {
                    string input = Console.ReadLine().Replace(" ", "");

                    bool isPassed = int.TryParse(input, out num);

                    if (isPassed && num <= _sortedCars.Count && num > 0)
                        break;

                    Console.WriteLine("Wrong Input");

                    continue;
                }
                catch
                {
                    Console.WriteLine("Wrong Input");
                }
            }
            return _sortedCars[num - 1];
        }

        public void Sort(double budgetLow, double budgetHigh, int conditionLow, int conditionHigh, string transmission)
        {
            foreach (NewCar car in _cars)
            {
                if (car._price > budgetLow && car._price <= budgetHigh
                    && car._technicalCondition >= conditionLow
                    && car._technicalCondition <= conditionHigh
                    && car._transmission == transmission)
                    _sortedCars.Add(car);
            }
        }
    }



    interface IOrder
    {
        string MakeOrder();
    }

    class Address
    {
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
    }

    class Buyer : Address
    {
        public string Name { get; set; }
        protected Address _address;
    }

    class Order : Buyer, IOrder
    {
        private string _name;
        private Address _address;
        public Car Car { get; set; }
        public Order(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public string MakeOrder()
        {
            return $"\t Car purchase order\n" +
                $"Order in the name: {_name}\n" +
                $"Deliver down the address:\n" +
                $"\tCity: {_address.City}\n" +
                $"\tStreet: {_address.Street}\n" +
                $"\tHouse: {_address.HouseNumber}\n" +
                $"Postal code: {_address.PostalCode}\n" +
                $"Car: {Car.ToString()}";
        }
    }



    interface IConsoleInterface<T>
    {
        public void AddItem(T item);

        public void Reset();

        public int GetCheckedInput();

        public double GetLowerValue();

        public double GetHigherValue(double lower = 0);

        public int GetLowerValueInt(int higher = 10);

        public int GetHigherValueInt(int lower = 0, int higher = 10);
    }

    class ConsoleInterface<T> : IConsoleInterface<T>
    {
        private List<T> _menu = new List<T>();


        public void AddItem(T item)
        {
            _menu.Add(item);
            Console.WriteLine(item.ToString());
        }

        public void Reset()
        {
            _menu.Clear();
        }

        public int GetCheckedInput()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine().Replace(" ", "");

                    int num;

                    bool isPassed = int.TryParse(input, out num);

                    if (isPassed && num <= _menu.Count && num >= 0)
                        return num;

                    Console.WriteLine("Wrong Input");

                    continue;
                }
                catch
                {
                    Console.WriteLine("Wrong Input");
                }
            }
        }

        public double GetLowerValue()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine().Replace(" ", "");

                    double num;

                    bool isPassed = double.TryParse(input, out num);

                    if (num >= 0 && isPassed)
                        return num;

                    Console.WriteLine("Wrong Input");

                    continue;
                }
                catch
                {
                    Console.WriteLine("Wrong Input");
                }
            }
        }

        public double GetHigherValue(double lower = 0)
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine().Replace(" ", "");

                    double num;

                    bool isPassed = double.TryParse(input, out num);

                    if (num >= lower && isPassed)
                        return num;

                    Console.WriteLine("Wrong Input");

                    continue;
                }
                catch
                {
                    Console.WriteLine("Wrong Input");
                }
            }
        }

        public int GetLowerValueInt(int higher = 10)
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine().Replace(" ", "");

                    int num;

                    bool isPassed = int.TryParse(input, out num);

                    if (num > 0 && num <= higher && isPassed)
                        return num;

                    Console.WriteLine("Wrong Input");

                    continue;
                }
                catch
                {
                    Console.WriteLine("Wrong Input");
                }
            }
        }

        public int GetHigherValueInt(int lower = 0, int higher = 10)
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine().Replace(" ", "");

                    int num;

                    bool isPassed = int.TryParse(input, out num);

                    if (num >= lower && num <= higher && isPassed)
                        return num;

                    Console.WriteLine("Wrong Input");

                    continue;
                }
                catch
                {
                    Console.WriteLine("Wrong Input");
                }
            }
        }
    }

}