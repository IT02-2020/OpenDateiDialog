using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class extract
    {
        public string Path { get; set; }


        public extract(string _path)
        {
            Path = _path;
        }


        public void getData()
        {
            int zeilen, spalten;

            string[] csvDatei = File.ReadAllLines(Path);

            zeilen = csvDatei.Length;
            spalten = csvDatei[0].Split(';').Length;

            string[,] matrix = new string[zeilen, spalten];

            for (int zeile = 0; zeile < zeilen; zeile++)
            {
                string[] werte = csvDatei[zeile].Split(';');

                for (int spalte = 0; spalte < spalten; spalte++)
                {
                    matrix[zeile, spalte] = werte[spalte];
                }
            }

        }

        public void convertToPerson(ref List<person> Personen)
        {
            string[] csvDatei = File.ReadAllLines(Path);
            string[] head = csvDatei[0].ToLower().Split(';');


            //string[] bla = { "vorname", "nachname", "alter", "geschlecht", "id" };


            int name = Array.IndexOf(head, "vorname");
            int surname = Array.IndexOf(head, "nachname");
            int age = Array.IndexOf(head,"alter");
            int gender = Array.IndexOf(head, "geschlecht");
            int id = Array.IndexOf(head, "id");

            //List<person> Personen = new List<person>();

            for (int i = 1; i < File.ReadAllLines(Path).Length; i++)
            {
                string[] subString = csvDatei[i].Split(';');
                Personen.Add(new person {Name = subString[name], SurName = subString[surname], Age = Convert.ToInt32(subString[age]), Gender = subString[gender], Id = Convert.ToInt32(subString[id]) });
            }

            
            
        }
    }
}
