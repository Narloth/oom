using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    class Beverage: Product, VAT
    {
        private double filling_quantity;

        public double Filling_quantity => filling_quantity;

        public Beverage(string name, decimal price, int number, double filling_quantity)
            : base(name, price, number)
        {
            this.Name = name;
            this.Price = price;
            this.Number = number;
            filling_quantity = Filling_quantity;
        }

        public decimal GetVATPrice()
        {
            decimal totalprice;
            totalprice = Price + ((Price / 100) * 20);
            return totalprice;
        }

        public override string PrintName()
        {
            string myname = Name;
            return myname;
        }


    }
}
