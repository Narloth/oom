using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task_3
{
    [TestFixture]
    class Tests
    {

        [Test]
        public void NameHasToBeAssigned()
        {
            Assert.Catch(() =>
            {
                var x = new Beverage("", 1.99M);
            });
        }


        [Test]
        public void PriceCannotBeZero()
        {
            Assert.Catch(() =>
            {
                var x = new Foodstuff("Apples", 0M, "");
            });
        }

        [Test]
        public void PriceCannotBeLessThanZero()
        {
            Assert.Catch(() =>
            {
                var x = new Foodstuff("Apples", -3M, "");
            });
        }

        [Test]
        public void fail_createProject()
        {
            Assert.Catch(() => 
            { var g = new Foodstuff("", 3M, "");
            });

        }

        [Test]
        public void ReturnsSameValue()
        {
            var x = new Beverage(0.5, 12);
            Assert.IsTrue(x.Quantity == 12);
        }

        [Test]
        public void AllValuesReturnedCorrectly()
        {
            var x = new Foodstuff("Nic Nacs", 1.25M, 1000, 5, "Nuts", vat.second);
            Assert.IsTrue(x.Name == "Nic Nacs");
            Assert.IsTrue(x.Price == 1.25M);
            Assert.IsTrue(x.Number == 1000);
            Assert.IsTrue(x.Quantity == 5);
            Assert.IsTrue(x.Allergens == "Nuts");
        }


        [Test]
        public void NoNegativeQuantityAllowed()
        {
            Assert.Catch(() =>
            {
                var x = new Foodstuff("Nic Nacs", 1.25M, 1000, -1, "Nuts", vat.second);
            });
        }

        [Test]
        public void NoNegativeQuantityAllowedEither()
        {
            Assert.Catch(() =>
            {
                var x = new Beverage("Nic Nacs", 1.25M, 1000, -1, vat.first);
            });
        }
    }


}

