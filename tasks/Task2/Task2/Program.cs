using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Product 
    {
        /// <summary>
        /// FIELDS: used to store data (as structs in C)
        /// </summary>
        private decimal price; //retail price
        private int number; //item number
        private int quantity; //quantity 
        private decimal vat; 
        private string name;

        /// <summary>
        /// CONSTRUCTORS: special methods used to initialize objects of a class
        /// automatically called when an object is created with the new keyword
        /// always named the same, as its containing class; no return type specified
        /// </summary>
        public Product(string newName, decimal newPrice, int newNumber, int newQuantity)
        {
            Name = newName;
            Price = newPrice;
            Number = newNumber;
            Quantity = newQuantity;
        }

        ///<summary>
        ///PROPERTIES: appear like public fields
        ///have special methods to set and/or get the property's value
        /// </summary>
        
        public string Name
        {
            get {return name; }
            set { if (value == null || value == "") throw new ArgumentOutOfRangeException("A name has to be assigned");
                name= value;
            }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value == 0 || value < 0) throw new ArgumentOutOfRangeException("Price must not be zero or less");
                price = value;                            
            }
        }

        public int Number
        {
            get { return number; }
            set
            {
                if (value == 0) throw new ArgumentOutOfRangeException("An item number has to be assigned");
                number = value;
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value == 0 || value < 0) throw new ArgumentOutOfRangeException("Quantity has to be at least 1");
                quantity = value;
            }
        }

        /*public decimal Vat
        {
            get { return (vat); }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("VAT must not be negative!");
                vat = value;
            }
        }*/

        public decimal CalculateVat(decimal vat)
        {
            return (price / 100 * 20);
        }

        public decimal GetVATPrice(decimal price)
        {
            decimal total_price = price + CalculateVat(vat);
            return total_price;
        }


    }

    //name, price, number, quantity, VAT
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Product("First", 5, 1000, 1);
            var b = new Product("Second", 5, 2000, 4);
            var c = new Product("Third", 3, 3000, 1);
            var d = new Product("Fourth", 5, 4000, 1);
            var e = new Product("Fifth", 5, 5000, 1);

            Console.WriteLine($"The product '{a.Name}' with number {a.Number} costs {a.Price} EUR net. Quantity: {a.Quantity}");
            Console.WriteLine("When VAT included the price amounts to {0}\n\n", a.GetVATPrice(a.Price));

            Console.WriteLine($"The product '{b.Name}' with number {b.Number} costs {b.Price} EUR net. Quantity: {a.Quantity}");
            Console.WriteLine("When VAT included the price amounts to {0}\n\n", a.GetVATPrice(a.Price));

            Console.WriteLine("{0} \n {1} \n {2} \n {3} \n {4}", c.Name, c.Price, c.Number, c.Quantity, c.GetVATPrice(c.Price));
        }
    }
    
}
