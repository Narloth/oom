using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task_3
{
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


    }


}

