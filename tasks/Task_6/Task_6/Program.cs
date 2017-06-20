using System;
using Newtonsoft.Json;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;
using System.Net.Http;

namespace Task_6
{
    class Program
    {


        static void Main(string[] args)
        {

            Json.Json_Examples();

            Console.WriteLine("\n");

            Push.Run1();
            Push.Run2();
            Push.Run3();


        }

    }

}
