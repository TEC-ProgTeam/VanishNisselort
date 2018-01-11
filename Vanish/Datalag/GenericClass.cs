using System;
//using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Vanish.Modeller;

namespace Vanish.Datalag
{
    public class GenericClass<T> : IComparer<T>
    {
        public int Compare(T x, T y)
        {
            throw new NotImplementedException();
        }
    }
}
