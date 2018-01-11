using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Vanish.Modeller;

namespace Vanish.Datalag
{
    class GenericClass
    {
        public delegate void GenericDelegate<T>(T item1, T item2);

        public void sorterGenerics<T>(GenericDelegate<T> method)
        {

            //Kunde k = new Kunde();
            //Type t = k.GetType();
            ////PropertyInfo[] props = t.GetProperties()[
            //k.GetType().GetProperties()[1].SetValue(k, "bo");

           // Delegate

            int tal = 99;


        }
    }
}
