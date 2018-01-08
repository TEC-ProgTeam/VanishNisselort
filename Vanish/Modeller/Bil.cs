using System;
using System.Collections.Generic;
using System.Text;

namespace Vanish.Modeller
{
    public class Bil
    {
        private string regNR;

        public string RegNR
        {
            get { return regNR; }
            set { regNR = value; }
        }

        private string maerke;

        public string Maerke
        {
            get { return maerke; }
            set { maerke = value; }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private int aargang;

        public int Aargang
        {
            get { return aargang; }
            set { aargang = value; }
        }

        private int km;

        public int Km
        {
            get { return km; }
            set { km = value; }
        }

        private int kundeID;

        public int KundeID
        {
            get { return kundeID; }
            set { kundeID = value; }
        }

    }
}
