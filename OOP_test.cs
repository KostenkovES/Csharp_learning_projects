using System;

namespace OOP_test
{
    // вынос перечислений для возможности их использования в любом классе
    public enum Color
    {
        Красный,
        Зеленый,
        Синий,
        Желтый,
        Черный,
        Коричневый
    }
    public enum Shape
    {
        Круглая,
        Прямоугольная,
        Треугольная
    }
    // общий интерфейс для яблок и ягод, реализующий доступность каждого фрукта,
    // в зависимости от времени года, через полиморфизм
    interface IFruit
    {
        string Availability();
    }
    // общий класс для яблок и ягод (абстрактный, т.к. у нас не бывает фрукта, который бы был не яблоком или не ягодой
    abstract class Fruit
    {
        protected string where_grows, availability;
        public string name;
        private double price;
        public Shape shape;
        public void Set_Name() {}
        // методы для установки и получения значений переменной price из-за параметров видимости
        public double Get_Price()
        {
            return price;
        }
        public void Set_Price(double price)
        {
            this.price = price;
        }
        // вывод тех параметров фрукта через общий для всех классов метод ToString
        public override string ToString()
        {
            return string.Format("Название: {0}\nПроизростает: {1}\nЦена за кг: {2} руб.\nФорма: {3}",
                name, where_grows, price, shape);
        }
    }
    // классы наследующие класс Fruit с конструкторами, методами проверки доступности и переопределением метода вывода
    class Apple : Fruit, IFruit
    {
        private string sort;
        private double avg_size;
        public Apple(string name, string sort, string where_grows, Shape shape, double price, double avg_size)
        {
            this.name = name;
            this.sort = sort;
            this.where_grows = where_grows;
            this.shape = shape;
            Set_Price(price);
            this.avg_size = avg_size;
            availability = Availability();
        }
        public string Availability()
        {
            if (DateTime.Now.Month >= 8 && DateTime.Now.Month <= 11)
                return ("Есть в наличие");
            else
                return ("Нет в наличие");
        }
        public override string ToString()
        {
            return base.ToString() + string.Format("\nСорт: {0}\nСредний размер: {1} куб.см.\nДоступность: {2}",
                sort, avg_size, availability);
        }
    }
    class Berry : Fruit, IFruit
    {
        private string sort;
        private Color color;
        private DateTime harvest_date;
        public Berry(string name, string sort, Color color, string where_grows, Shape shape, 
            double price, DateTime harvest_date)
        {
            this.name = name;
            this.color = color;
            this.where_grows = where_grows;
            this.shape = shape;
            Set_Price(price);
            this.harvest_date = harvest_date;
            this.sort = sort;
            availability = Availability();
        }
        public string Availability()
        {
            if (DateTime.Now.Month >= 6 && DateTime.Now.Month <= 7)
                return ("Есть в наличие");
            else
                return ("Нет в наличие");
        }
        public override string ToString()
        {
            return base.ToString() + string.Format("\nЦвет: {0}\nДата сбора урожая: {1}.\nСорт: {2}\nДоступность: {3}",
                color, harvest_date, sort, availability);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IFruit fruits = new Apple("Яблоко", "Антоновка", "Россия", Shape.Круглая, 10.87, 1.1);
            Console.WriteLine(fruits);
            Console.WriteLine();
            IFruit berrys = new Berry("Ежевика", "Антоновка", Color.Черный, "Россия", Shape.Треугольная, 1211.32, DateTime.Now);
            Console.WriteLine(berrys);
            Console.ReadLine();
        }

    }
}
