using System;
using Vanish.Datalag;

namespace Vanish
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // tester lige klassen!!
            DataLag lag = new DataLag();
            lag.hentKunde(1);
        }
    }
}
