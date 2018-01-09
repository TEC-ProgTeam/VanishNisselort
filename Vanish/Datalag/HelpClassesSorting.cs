using System;
using System.Collections.Generic;
using System.Text;
using Vanish.Modeller;

namespace Vanish.Datalag
{
    public class HelpClassesSorting
    {
        /// <summary>
        /// Bil - IComparer - Classes
        /// </summary>
        public class SorterBilEfterAargangIcompare : IComparer<Bil>
        {
            public int Compare(Bil x, Bil y)
            {
                if (x.Aargang > y.Aargang)
                {
                    return 1;
                }else if (x.Aargang < y.Aargang)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public class sorterBilEfterModelIcompare : IComparer<Bil>
        {
            public int Compare(Bil x, Bil y)
            {
                if (x.Model.CompareTo(y.Model) > 0)
                {
                    return 1;
                }else if (x.Model.CompareTo(y.Model) < 0)
                {
                    return -1;
                }
                else
                    return 0;
            }
        }

        public class sorterBilEfterMaerkeICompare : IComparer<Bil>
        {
            public int Compare(Bil x, Bil y)
            {
                if (x.Maerke.CompareTo(y.Maerke) > 0) return 1; else if (x.Maerke.CompareTo(y.Maerke) < 0)
                    return -1;
                else
                    return 0;
            }
        }

        public enum SorteringsMuligheder { Aargang, Model, Maerke }

        public class SorterBilKlasseICompare : IComparer<Bil>
        {
            private SorteringsMuligheder muligheder;
            SorterBilKlasseICompare(SorteringsMuligheder mulighed)
            {
                // hvad skal der så ske herinde??
                // den kan være 3 forskellige lige nu.....
                muligheder = mulighed;
            }

            public int Compare(Bil x, Bil y)
            {
                if (muligheder == SorteringsMuligheder.Aargang)
                {
                    if (x.Aargang > y.Aargang)
                    {
                        return 1;
                    }
                    else if (x.Aargang < y.Aargang)
                        return -1;
                    else
                        return 0;
                } else if (muligheder == SorteringsMuligheder.Maerke)
                {
                    if (x.Maerke.CompareTo(y.Maerke) > 0)
                    {
                        return 1;
                    }
                    else if (x.Maerke.CompareTo(y.Maerke) <0)
                        return -1;
                    else
                        return 0;
                } else if (muligheder == SorteringsMuligheder.Model)
                {
                    if (x.Model.CompareTo(y.Model) > 0)
                    {
                        return 1;
                    }
                    else if (x.Model.CompareTo(y.Model) < 0)
                        return -1;
                    else
                        return 0;
                }

                return 5;
            }
            
        }
    }
}
