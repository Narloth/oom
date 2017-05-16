using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{

    /// <summary>
    /// an abstract base class containing only abstract methods
    /// </summary>
    public interface Vat
    {
        double GetVATPrice(Vat_class rate);

    }

    class Product
    {
        private string name;
        private double price;
        private int number;
        private int quantity;

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value == "") throw new ArgumentOutOfRangeException("A name has to be assigned");
                name = value;
            }
        }

        public double Price
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

    }

    class Beverage : Product, Vat
    {
        
        public Beverage(string newName, double newPrice, int newNumber, int newQuantity, Vat_class rate)
        {
            Name = newName;
            Price = newPrice;
            Number = newNumber;
            Quantity = newQuantity;

        }
            

        public double GetVATPrice(Vat_class rate)
        {
            rate = Vat_class.first;
            double total_price = Price + (Price / 100 * 20);
            return total_price;
        }
           
    }

    class Foodstuff : Product, Vat
    {

        private string allergens;

        public Foodstuff (string newName, double newPrice, int newNumber, int newQuantity, string newAllergens, Vat_class rate)
        {
            Name = newName;
            Price = newPrice;
            Number = newNumber;
            Quantity = newQuantity;
            Allergens = newAllergens;
        }


        public double GetVATPrice(Vat_class rate)
        {
            rate = Vat_class.second;
            double total_price = Price + (Price / 100 * 10);
            return total_price;
        }

        public string Allergens
        {
            get { return allergens; }
            set
            {
                allergens = value;
            }
        }
    }

    class FWine: Product, Vat
    {
        public FWine(string newName, double newPrice, int newNumber, int newQuantity, Vat_class rate)
        {
            Name = newName;
            Price = newPrice;
            Number = newNumber;
            Quantity = newQuantity;
        }

        public double GetVATPrice(Vat_class rate)
        {
            rate = Vat_class.third;
            double total_price = Price + (Price / 100 * 13);
            return total_price;
        }
    }

    public enum Vat_class
    {
        first = 20,

        second = 10,

        third = 13
    }



    class Program
    {

        static void Main(string[] args)
        {
            var myArray = new Vat[]
            {
            new Beverage("First", 7, 1000, 1, Vat_class.first),
            new Beverage("Second", 5, 2000, 4, Vat_class.first),
            new Beverage("Third", 3, 3000, 1, Vat_class.first),
            new Foodstuff("Salt", 5, 4000, 1, "none", Vat_class.second),
            new Foodstuff("Fifth", 5, 5000, 1, "", Vat_class.second),
            //new FWine("...", 13.99, 1234, Vat_class.third),
            };

            var p_price = Vat_class.first;
            Vat_class rate = Vat_class.first;
            var test = Convert.ChangeType(rate, Enum.GetUnderlyingType(typeof(Vat_class)));

            Console.WriteLine("Vat_rate {0} to {1}", rate, test);


            Console.WriteLine("VAT rates: \n first: 20% \n second: 10% \n third: 13%\n");

           foreach (var x in myArray)
            {
                Console.WriteLine($"The price of {x} including VAT amounts to: {x.GetVATPrice(p_price)}.");
            }

            
        }
    }
}
