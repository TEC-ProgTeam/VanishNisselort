using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Vanish.Modeller;

namespace Vanish.IO
{
    class FilLag
    {
        /// <summary>
        /// Metode, der kan skrive liste af Kunde objekter til csv-fil
        /// NB! Filen må ikke findes i forvejen
        /// Stien til filen: c:\vanish\MyTestKundeListe.txt
        /// </summary>
        /// <param name="kliste">Liste af Kunde objekter</param>
        public static void SkrivTilFil(List<Kunde> kliste)
        {
            StringBuilder txt = new StringBuilder();
            int klisteAntal = 1;
            const string folder = @"c:\vanish";
            const string path = @"c:\test\MyTestKundeListe.txt";

            foreach (var kelement in kliste)
            {
                int antal = 1;
                Type t = kelement.GetType();

                PropertyInfo[] props = t.GetProperties();

                foreach (var prop in props)
                {
                    if (prop.GetIndexParameters().Length == 0)
                    {
                        txt.Append(prop.GetValue(kelement));
                        antal++;
                        if (antal <= props.Length)
                        {
                            txt.Append(",");
                        }
                    }
                }

                if (kliste.Count > klisteAntal)
                {
                    txt.Append(Environment.NewLine);
                }
                klisteAntal++;
            }

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a Folder for the file, no problem if it exists
                Directory.CreateDirectory(folder);
                // Create a file to write to.
                File.WriteAllText(path, txt.ToString());
            }
        }

        /// <summary>
        /// Metode, der skriver et enkelt objekt til csv-fil
        /// Filen må ikke findes i forvejen
        /// NB! Filen må ikke findes i forvejen
        /// Stien til filen: c:\vanish\MyTestKunde.txt 
        /// </summary>
        /// <param name="obj">Bil eller Kunde objekt</param>
        public static void SkrivTxtFil(object obj)
        {
            StringBuilder txt = new StringBuilder();
            int antal = 1;
            Type t = obj.GetType();
            PropertyInfo[] props = t.GetProperties();
            const string folder = @"c:\vanish";
            const string path = @"c:\vanish\MyTestKunde.txt";

            foreach (var prop in props)
            {
                if (prop.GetIndexParameters().Length == 0)
                {
                    txt.Append(prop.GetValue(obj));
                    antal++;
                    if (antal <= props.Length)
                    {
                        txt.Append(",");
                    }
                }
            }

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a Folder for the file, no problem if it exists
                Directory.CreateDirectory(folder);
                // Create a file to write to.
                File.WriteAllText(path, txt.ToString());
            }
        }
        /// <summary>
        /// Læser en csv-fil, og returnerer en liste af kunde objekter,
        /// der hvor metoden kaldes fra.
        /// Kan benyttes til at behandle data fra fil og lave insert den vej.
        /// Mangler at blive tilrettet, så objekt og filnavn indgår i metodekald.
        /// </summary>
        /// <returns>List Kunde</returns>
        public static List<Kunde> LaesFraFil()
        {
            //Læse fra en csv-fil en linje ad gangen - sti til fil
            const string path = @"c:\vanish\MyTestKundeListe.txt";
            int counter = 0;
            string line;
            string[] arrLine;

            //liste, der opbygges og returneres
            List<Kunde> fraFil = new List<Kunde>();

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                arrLine = line.Split(",");
                System.Console.WriteLine(line);
                counter++;

                Kunde kk = new Kunde();
                Type t = kk.GetType();

                // tester p.t. kun for Int32 variable type, alle andre er string
                for (int i = 0; i < arrLine.Length; i++)
                {
                    if (kk.GetType().GetProperties()[i].PropertyType.Name == "Int32")
                    {
                        kk.GetType().GetProperties()[i].SetValue(kk, int.Parse(arrLine[i]));
                    }
                    else
                    {
                        kk.GetType().GetProperties()[i].SetValue(kk, arrLine[i]);
                    }

                }
                fraFil.Add((kk));
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);

            return fraFil;
        }
    }
}
