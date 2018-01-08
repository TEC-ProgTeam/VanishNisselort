using System;
using System.Collections.Generic;
using System.Dynamic;
using Vanish.Datalag;
using Vanish.Modeller;

namespace Vanish
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // tester lige klassen!!
            DataLag lag = new DataLag();
            //lag.hentKunde(1);
            //DataLag
            List<Bil> list = lag.sorterBilEfterAargangLINQ(false);
            foreach (var b in list)
            {
                Console.WriteLine(b.Aargang);
            }

            Console.ReadKey();
        }
    }
}
