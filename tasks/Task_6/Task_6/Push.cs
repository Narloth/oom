using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using static System.Console;
using System.Threading;

namespace Task_6
{
    class Push
    {
        public static void Run1()
        {
            //Subject is an observable and must produce values and must call OnNext to notify its Observers
            //Subject of T also implements the IObserver of the interface

            var producer = new Subject<Beverage>();

            producer.Subscribe(x => Console.WriteLine($"Produced: {x}"));

            for (var i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
                producer.OnNext(new Beverage("Cola", 1.99M, 1111, 0.5));
               
            }
        }

        public static void Run2()
        {
            Subject<Beverage> test = new Subject<Beverage>();

            var subscription = test.Subscribe(
                x => Console.WriteLine($"Created: {x}"),
                () => Console.WriteLine("terminated"));

            test.OnNext(new Beverage("Fanta", 3M, 3, 0.5));
            test.OnNext(new Beverage("Red Bull", 4M, 4, 0.5));
            test.OnNext(new Beverage("Tonic", 5M, 5, 0.5));
            test.OnNext(new Beverage("Cola", 6M, 6, 0.5));

            Console.WriteLine("Press key");
            Console.ReadKey();

            test.OnCompleted();
            subscription.Dispose();
        }

        private static Product[] myproducts => new Product[]
        {
                new Beverage("Coca Cola", 1.25M, 1, 0.5),
                new Beverage("Fanta", 1.25M, 2, 0.5),
                new Beverage("Red Bull", 1.00M, 3, 0.25),
                new Foodstuff("Milka Brownies", 3.00M, 4, "Nuts"),
                new Foodstuff("Cookies", 1.05M, 5,""),
                new Foodstuff("Snickers", 1.99M, 6, "Nuts"),
        };

        public static void Run3()
        {
            var tasks = new List<Task<decimal>>();

            foreach (var x in myproducts)
            {
                var task = Task.Run(() =>
                {
                    Console.WriteLine("I'm doing something here: {}", x.Price);
                    Task.Delay(TimeSpan.FromSeconds(3.0)).Wait();
                    Console.WriteLine("Well... something probably happened" + x.Price);
                    return x.Price;
                });

                tasks.Add(task);
                WriteLine($"Product {x.Name} has the price: {x.Price}");
            }


        }

     
    }
}
