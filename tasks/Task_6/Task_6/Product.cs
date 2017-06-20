using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    abstract class Product
    {
        /// <summary>
        /// fields
        /// </summary>
        private string name;
        private decimal price;
        private int number;
        private int quantity;

        /// <summary>
        /// properties
        /// </summary>
        public string Name
        {
            get
            { return name; }
            set
            {
                if (value.Equals("")) throw new ArgumentOutOfRangeException("A name must be assigned");
                name = value;
            }
        }

        public decimal Price
        { get
            { return price; }
          set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("You must assign a positive value as price");
                price = value;
            }
         }

        public int Number
        {
            get
            { return number; }
            set
            {
                number = value;
            }
        }

        public int Quantity
        {
            get; set;
        }

        /// <summary>
        /// constructors
        /// </summary>
        public Product(string name, decimal price, int number)
        {
            Name = name;
            Price = price;
            Number = number;
        }

        public Product(string name, decimal price, int number, int quantity)
        {
            Number = number;
            Price = price;
            Number = number;
            Quantity = quantity;
        }
        /// <summary>
        /// methods
        /// </summary>
        public virtual string PrintName()
        {
            string myname = Name;
            return myname;
        }

    }
}
