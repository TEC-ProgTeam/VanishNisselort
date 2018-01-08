using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Vanish.Databaselag;
using Vanish.Modeller;

namespace Vanish.Datalag
{
    public class DataLag
    {
        #region KUNDE
        public Kunde hentKunde(int kundeId)
        {
            string sql = "select * from kunde where kundeId = " + kundeId;
            DataTable kundeDataTable = SQL.Select(sql);
            return new Kunde()
            {
                Efternavn = kundeDataTable.Rows[0]["Efternavn"].ToString(),
                Fornavn = kundeDataTable.Rows[0]["Fornavn"].ToString(),
                Email = kundeDataTable.Rows[0]["Email"].ToString(),
                Husnr = Convert.ToInt32(kundeDataTable.Rows[0]["Husnr"].ToString()),
                Mobil = kundeDataTable.Rows[0]["Mobil"].ToString(),
                KundeID = Convert.ToInt32(kundeDataTable.Rows[0]["KundeID"]),
                Postnr = Convert.ToInt32(kundeDataTable.Rows[0]["Postnr"]),
                Vejnavn = kundeDataTable.Rows[0]["Vejnavn"].ToString()
            };
        }

        public List<Kunde> hentKunder()
        {
            string sql = "select * from kunde";
            List<Kunde> kundeList = new List<Kunde>();
            DataTable kundeDataTable = SQL.Select(sql);
            foreach (DataRow kunde in kundeDataTable.Rows)
            {
                kundeList.Add(new Kunde()
                {
                    Efternavn = kunde["Efternavn"].ToString(),
                    Fornavn = kunde["Fornavn"].ToString(),
                    Email = kunde["Email"].ToString(),
                    Husnr = Convert.ToInt32(kunde["Husnr"]),
                    KundeID = Convert.ToInt32(kunde["KundeId"]),
                    Mobil = kunde["Mobil"].ToString(),
                    Postnr = Convert.ToInt32(kunde["Postnr"]),
                    Status = Convert.ToInt32(kunde["Status"]),
                    Type = Convert.ToInt32(kunde["Type"]),
                    Vejnavn = kunde["Vejnavn"].ToString()
                });
            }

            return kundeList;
        }

        public void opdaterKunde(Kunde k)
        {
            // kan kodes på flere måder - kan gøre det lidt slavisk eller vi kan smide en hel kunde med som parameter til en anden klasse.
            string sql = "update kunde set fornavn = '" + k.Fornavn +
                         "', efternavn='"+k.Efternavn+"',vejnavn='"+k.Vejnavn+"', husnr="+k.Husnr+", postnr="+k.Postnr+", mobil='"+k.Mobil+
                         "', email='"+k.Email+"',type="+k.Type+",status="+k.Status+" where kundeID = "+k.KundeID;
            SQL.insert(sql);

        }
        public void opretKunde(Kunde k)
        {
            // vi tjekker ikke om det går godt!!
            string sql = "insert into kunde values ('" + k.Fornavn + "','" + k.Efternavn + "','" + k.Vejnavn + "'," +
                         k.Husnr + "," + k.Postnr + "," + k.Mobil + "," + k.Email + "," + k.Type + "," + k.Status + ")";
            SQL.insert(sql);
        }
       
        public void setStatusKunde(int kundeId, int status)
        {
            Kunde tempKunde = hentKunde(kundeId);
            tempKunde.Status = status;
            opdaterKunde(tempKunde); // dette er ikke kodet færdigt endnu
        }

#endregion KUnde
        // måske skulle jeg lave en mapper metode!!
        // biler
        #region Biler
        //CRUD
        public Bil hentBil(int regNR)
        {
            string sql = "select bil.*, kundeid from bil, kunde where regNr = '" + regNR + "' and kunde.kundeID = bil.kundeID";
            DataTable bilDataTable = SQL.Select(sql);

            return new Bil()
            {
                Km = Convert.ToInt32(bilDataTable.Rows[0]["Km"]),
                Maerke = bilDataTable.Rows[0]["Maerke"].ToString(),
                Model = bilDataTable.Rows[0]["Model"].ToString(),
                RegNR = bilDataTable.Rows[0]["RegNR"].ToString(),
                Aargang = Convert.ToInt32(bilDataTable.Rows[0]["Aargang"]),
                KundeID = Convert.ToInt32(bilDataTable.Rows[0]["KundeID"])
            };
        }

        public List<Bil> hentBiler()
        {
            string sql = "select * from bil";
            DataTable bilDataTable = SQL.Select(sql);
            List<Bil> bilList = new List<Bil>();
            foreach (DataRow bilData in bilDataTable.Rows)
            {
                bilList.Add(new Bil()
                {
                    Km = Convert.ToInt32(bilData["Km"]),
                    KundeID = Convert.ToInt32(bilData["KundeID"]),
                    Maerke = bilData["Maerke"].ToString(),
                    Model = bilData["Model"].ToString(),
                    RegNR = bilData["Regnr"].ToString(),
                    Aargang = Convert.ToInt32(bilData["Aargang"])
                });
            }
            return bilList;
        }
        public void opdaterBil(Bil b)
        {
            string sql = "update bil set maerke='"+b.Maerke+"', model='"+b.Model+"', aargang="+b.Aargang+",km="+b.Km+" where kundeID = "+b.KundeID;
            SQL.insert(sql);
        }

        public void opretBil(Bil b)
        {
            string sql = "insert into bil values ('" + b.RegNR + "','" + b.Maerke + "','" + b.Model + "'," + b.Aargang +
                         "," + b.Km + "," + b.KundeID + ")";
            SQL.insert(sql);
        }


        // de sorteringsalgoritmer vi skal skrive kan skrives på 2 måder!!
        // interfaces og LINQ
        /// <summary>
        /// INTERFACES
        /// her kan vi kode det på 3 måder
        /// 
        /// 
        /// 1) 
        /// 
        /// 
        /// 2)
        /// 
        /// 
        /// 3)
        /// </summary>
        /// <returns></returns>
        public List<Bil> sorterBilEfterAargangInterface()
        {

            // skriver lige noget her
            return new List<Bil>();
        }
        public List<Bil> sorterBilEfterModelInterface() { return new List<Bil>(); }
        public List<Bil> sorterBilEfterMaerkeInterface() { return new List<Bil>(); }
        public List<Bil> returnerKundesBilerInterface() { return new List<Bil>(); }



        public List<Bil> sorterBilEfterAargangLINQ(bool sorteringsOrden = true)
        {
            return sorteringsOrden == true
                ? (from bil in hentBiler()
                    orderby bil.Aargang
                    select bil).ToList()
                : (from bil in hentBiler()
                    orderby bil.Aargang descending
                    select bil).ToList();
            //List<Bil> bilListSorteret = new List<Bil>();
            //if (sorteringsOrden == true)
            //{
            //    bilListSorteret = (from bil in hentBiler()
            //        orderby bil.Aargang
            //        select bil).ToList();
            //}
            //else
            //{
            //    bilListSorteret = (from bil in hentBiler()
            //        orderby bil.Aargang descending
            //        select bil).ToList();
            //}

            //return bilListSorteret;
        }

        public List<Bil> sorterBilEfterModelLINQ(bool sorteringsOrden = true)
        {
            return sorteringsOrden == true
                ? (from bil in hentBiler()
                    orderby bil.Model
                    select bil).ToList()
                : (from bil in hentBiler()
                    orderby bil.Model descending
                    select bil).ToList();
        }

        public List<Bil> sorterBilEfterMaerkeLINQ(bool sorteringsOrden = true)
        {
            return sorteringsOrden == true
                   ? (from bil in hentBiler()
                    orderby bil.Maerke
                        select bil).ToList()
                : (from bil in hentBiler()
                    orderby bil.Maerke descending 
                        select bil).ToList();
        }

        public List<Bil> returnerKundesBilerLINQ(int kundeID, bool sorteringsOrden = true)
        {
            return sorteringsOrden == true
                ? (from bil in hentBiler()
                    where bil.KundeID == kundeID
                    orderby bil.Aargang
                    select bil).ToList()
                : (from bil in hentBiler()
                    where bil.KundeID == kundeID
                    orderby bil.Aargang descending
                    select bil).ToList();
        }

        #endregion biler
        // kundeperspektiv
        // alle biler - samt søge på alle kunde ting!!


    }
}
