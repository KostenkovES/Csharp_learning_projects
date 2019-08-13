using System;
using System.Linq;

namespace vehicle_game
{
    struct Stats
    {
        public string Type, Error;
        public int Fuel, Distance;
        public float Durability;
    }
    class Vehicle
    {
        public string Type;
        public int Fuel, FuelConsumption;
        public float Durability;

        // конструктор транспортных средств
        public Vehicle(int Fuel, int FuelConsumption, string Type)
        {
            this.Fuel = Fuel;
            this.FuelConsumption = FuelConsumption;
            this.Type = Type;
            Durability = 100;
        }

        // изменение параментор транспортных средств при движение в зависимости от их типа
        public Stats Move(int Distance)
        {
            Stats stats = new Stats();
            switch (this.Type)
            {
                case "Car":
                    {
                        if (this.Fuel > this.FuelConsumption * Distance & this.Durability > 1 * Distance)
                        {
                            this.Fuel -= this.FuelConsumption * Distance;
                            this.Durability -= 1 * Distance;
                            stats.Fuel = this.Fuel;
                            stats.Durability = this.Durability;
                            stats.Type = this.Type;
                            stats.Distance = Distance;
                        }
                        else
                            stats.Error = "Движение невозможно";
                        break;
                    }
                case "HorseCarriage":
                    {
                        if (this.Fuel > this.FuelConsumption * Distance & this.Durability > 10 * Distance)
                        {
                            this.Fuel -= this.FuelConsumption * Distance;
                            this.Durability -= 10 * Distance;
                            stats.Fuel = this.Fuel;
                            stats.Durability = this.Durability;
                            stats.Type = this.Type;
                            stats.Distance = Distance;
                        }
                        else
                            stats.Error = "Движение невозможно";
                        break;
                    }
                case "Plane":
                    {
                        if (this.Fuel > this.FuelConsumption * Distance & this.Durability > (float)0.1 * Distance)
                        {
                            this.Fuel -= this.FuelConsumption * Distance;
                            this.Durability -= (float)0.1 * Distance;
                            stats.Fuel = this.Fuel;
                            stats.Durability = this.Durability;
                            stats.Type = this.Type;
                            stats.Distance = Distance;
                        }
                        else
                            stats.Error = "Движение невозможно";
                        break;
                    }
                case "Boat":
                    {
                        if (this.Fuel > this.FuelConsumption * Distance & this.Durability > (float)0.5 * Distance)
                        {
                            this.Fuel -= this.FuelConsumption * Distance;
                            this.Durability -= (float)0.5 * Distance;
                            stats.Fuel = this.Fuel;
                            stats.Durability = this.Durability;
                            stats.Type = this.Type;
                            stats.Distance = Distance;
                        }
                        else
                            stats.Error = "Движение невозможно";
                        break;
                    }
                default:
                    break;
            }
            return stats;
        }
    }
    class Program
    {
        // вывод на экран результатов движения с оставшимися характеристиками транспортного средства
        static void Print(Stats stats)
        {
            if (stats.Error == "Движение невозможно")
                Console.WriteLine("\nДвижение невозможно\n");
            else
            {
                Console.WriteLine("\n{0} передвинулся на {1}, осталось {2} топлива, {3:0.0} прочности\n",
                    stats.Type, stats.Distance, stats.Fuel, stats.Durability);
            }
        }
        // вывод общей статистики по всем транспортным средсвтам
        static void PrintAll(Vehicle[] vehicleForPrint)
        {
            Console.WriteLine("{0,-15}{1,-20}{2,-20}", "Тип ТС", "Оставшееся топливо", "Оставшаяся прочность");
            for (int i = 0; i < vehicleForPrint.Length; i++)
            {
                Console.WriteLine("{0,-15}{1,-20}{2,-20:0.0}", vehicleForPrint[i].Type, vehicleForPrint[i].Fuel,
                    vehicleForPrint[i].Durability);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            // инициализация параметров транспортных средств фиксированными значеняими
            Vehicle car = new Vehicle(600, 8, "Car");
            Vehicle horseCarriage = new Vehicle(100, 2, "HorseCarriage");
            Vehicle plane = new Vehicle(12000, 100, "Plane");
            Vehicle boat = new Vehicle(25000, 150, "Boat");
            Vehicle[] vehicleForPrint = { car, horseCarriage, plane, boat };
            Stats stats;
            string Question;
            int QuestionAboutDistance = 0;
            string[] Answers = { "Car", "HorseCarriage", "Plane", "Boat", "Stats" , "" };
            while (true)
            {
                Console.WriteLine("На каком транспортном средве мы будем двигаться ?\n" +
                    "Доступны Car, HorseCarriage, Plane и Boat (общая статистика доступна по команде \"Stats\")\n" +
                    "Для выхода из программы нажмите Enter");
                Question = Console.ReadLine();
                // проверка ввода пользователя на корректность
                while (true)
                {
                    if (Answers.Contains(Question))
                        break;
                    else
                        Console.WriteLine("Некоректный ввод, попробуйте снова");
                    Question = Console.ReadLine();
                }
                // выход из программы, при нажатии пользователем Enter
                if (Question == "")
                {
                    break;
                }
                Console.WriteLine("\nНа какое растояние будем двигаться ? \n");
                // получение от пользователя информации о расстоянии, при выборе транспортного средства
                while (true)
                {
                    if (Question == "Stats")
                    {
                        break;
                    }
                    else
                    {
                        if (!Int32.TryParse(Console.ReadLine(), out QuestionAboutDistance))
                        {
                            Console.WriteLine("\nНекоректный ввод, попробуйте снова\n");
                        }
                        else
                            break;
                    }
                }
                // изменение параметров транспортного средства в результате движения
                switch (Question)
                {
                    case "Car":
                        {
                            stats = car.Move(QuestionAboutDistance);
                            Print(stats);
                            break;
                        }
                    case "HorseCarriage":
                        {
                            stats = horseCarriage.Move(QuestionAboutDistance);
                            Print(stats);
                            break;
                        }
                    case "Plane":
                        {
                            stats = plane.Move(QuestionAboutDistance);
                            Print(stats);
                            break;
                        }
                    case "Boat":
                        {
                            stats = boat.Move(QuestionAboutDistance);
                            Print(stats);
                            break;
                        }
                    case "Stats":
                        {
                            PrintAll(vehicleForPrint);
                            break;
                        }
                }
            }
        }
    }
}
