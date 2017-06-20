using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task_6
{
    class Json
    {
        public static void Json_Examples()
        {
            var myArray = new VAT[]
            {
            new Beverage("Coca Cola", 1.25M, 1, 0.5),
            new Beverage("Fanta", 1.25M, 2, 0.5),
            new Beverage("Red Bull", 1.00M, 3, 0.25),
            new Foodstuff("Milka Brownies", 3.00M, 4, "Nuts"),
            new Foodstuff("Cookies", 1.05M, 5,""),
            new Foodstuff("Snickers", 1.99M, 6, "Nuts"),
            };

            Console.WriteLine("VAT rates: \n first: 20%     second: 10%     third: 13%\n");

            foreach (var x in myArray)
            {
                Console.WriteLine("{0}", x.GetVATPrice());
            }

            string json = JsonConvert.SerializeObject(myArray, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

            Console.WriteLine("Json string:");
            Console.WriteLine(json);


            var data = JsonConvert.DeserializeObject<VAT[]>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
        }
    }
}
