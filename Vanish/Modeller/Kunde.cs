using System;
using System.Collections.Generic;
using System.Text;

namespace Vanish.Modeller
{
    public class Kunde
    {
        private int kundeID;

        public int KundeID
        {
            get { return kundeID; }
            set { kundeID = value; }
        }

        private string fornavn;

        public string Fornavn
        {
            get { return fornavn; }
            set { fornavn = value; }
        }

        private string efternavn;

        public string Efternavn
        {
            get { return efternavn; }
            set { efternavn = value; }
        }

        private string vejnavn;

        public string Vejnavn
        {
            get { return vejnavn; }
            set { vejnavn = value; }
        }

        private int husnr;

        public int Husnr
        {
            get { return husnr; }
            set { husnr = value; }
        }

        private int postnr;

        public int Postnr
        {
            get { return postnr; }
            set { postnr = value; }
        }

        private string mobil;

        public string Mobil
        {
            get { return mobil; }
            set { mobil = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private int type;

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
