using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;


namespace Task_3
{

    /// <summary>
    /// interface: an abstract base class containing only abstract methods
    /// </summary>
    public interface Vat
    {
        void GetVATPrice();
        void PrintName();

    }

    /// <summary>
    /// abstract base class; cannot be instantiated
    /// </summary>
    abstract class Product
    {
        /// <summary>
        /// fields
        /// </summary>
        private string name;
        private decimal price;
        private int number;

        /// <summary>
        /// properties: appear like public fields; have special methods to set / get the property's value
        /// </summary> 
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Equals("")) throw new ArgumentOutOfRangeException("A name has to be assigned");
                name = value;
            }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Price must not be negative");
                price = value;
            }
        }

        public int Number
        {
            get { return number; }
            set
            {
                number = value;

            }
        }

        public Product(string name, decimal price, int number, vat rate)
        {
            Name = name;
            Price = price;
            Number = number;

        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public Product() { }

    }

    class Beverage : Product, Vat
    {
        /// <summary>
        /// fields
        /// </summary>
        private double filling_quantity;
        private int quantity;

        /// <summary>
        /// properties
        /// </summary>
        public double Filling_Quantity
        {
            get { return filling_quantity; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Filling quantity has to be greater than zero");
                filling_quantity = value;
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("No negative quantity allowed!");
                quantity = value;
            }
        }

        /// <summary>
        /// constructors: special methods used to initialize objects of a class 
        /// </summary>
        [JsonConstructor]
        public Beverage(string name, decimal price, int number, double filling_quantity, vat rate)
            : base(name, price, number, rate)
        {
            Filling_Quantity = filling_quantity;

        }

        public Beverage(string name, decimal price)
            : base(name, price) { }

        public Beverage(double filling_quantity, int quantity)
        {
            Quantity = quantity;
        }

        /// <summary>
        /// methods
        /// </summary>
        public void GetVATPrice()
        {
            decimal total_price = Price + (Price / 100 * 20);
            Console.WriteLine("Product: {0}     Price: {1}      Vat rate: {2}       Total price: {3}", Name, Price, vat.first, total_price);
        }

        public void PrintName()
        {
            Console.WriteLine(Name);
        }


    }

    class Foodstuff : Product, Vat
    {

        private string allergens;
        private int quantity;

        [JsonConstructor]
        public Foodstuff(string name, decimal price, int number, int newQuantity, string newAllergens, vat rate)
            : base(name, price, number, rate)
        {
            Quantity = newQuantity;
            Allergens = newAllergens;
        }

        public Foodstuff(string name, decimal price, string allergens)
            : base(name, price)
        {
            Allergens = allergens;
        }

        public Foodstuff(string name, string allergens)
        {
            Name = name;
            Allergens = allergens;
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("No negative quantity allowed!");
                quantity = value;
            }
        }


        public string Allergens
        {
            get { return allergens; }
            set
            {
                allergens = value;
            }
        }

        public void GetVATPrice()
        {
            decimal total_price = Price + (Price / 100 * 10);
            Console.WriteLine("Product: {0}     Price: {1}      Vat rate: {2}       Total price: {3}", Name, Price, vat.second, total_price);
        }

        public void PrintName()
        {
            Console.WriteLine(Name);
        }

    }


    public enum vat
    {
        first = 20,

        second = 10,

    }



    class Program
    {

        static void Main(string[] args)
        {
            var myArray = new Vat[]
            {
            new Beverage("Coca Cola", 1.25M, 1, 0.5, vat.first),
            new Beverage("Fanta", 1.25M, 2, 0.5, vat.first),
            new Beverage("Red Bull", 1.00M, 3, 0.25, vat.first),
            new Foodstuff("Milka Brownies", 3.00M, 4, 8, "Nuts", vat.second),
            new Foodstuff("Cookies", 1.05M, 5, 1, "", vat.second),
            new Foodstuff("Snickers", 1.99M, 6, 10, "Nuts", vat.second),
            };

            Console.WriteLine("VAT rates: \n first: 20%     second: 10%     third: 13%\n");

            foreach (var x in myArray)
            {
                x.GetVATPrice();
            }

            string json = JsonConvert.SerializeObject(myArray, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

            Console.WriteLine("Json string:");
            Console.WriteLine(json);


            var data = JsonConvert.DeserializeObject<Vat[]>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            Console.WriteLine("\n");

            foreach (var x in data)
            {
                x.PrintName();
            }

                         


        }
    }
}

