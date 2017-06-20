using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    class Foodstuff: Product, VAT
    {
        private string allergen;

        public string Allergen
        {
            get
            { return allergen; }
            set
            {
                allergen = value;
            }
        }

        public Foodstuff(string name, decimal price, int number, string allergen)
            : base(name, price, number)
        {
            this.Name = name;
            this.Price = price;
            this.Number = number;
            Allergen = allergen;
        }

        public decimal GetVATPrice()
        {
            decimal totalprice;
            totalprice = Price + ((Price / 100) * 10);
            return totalprice;
        }

        public override string PrintName()
        {
            base.PrintName();
            return Name;
        }
    }
}
