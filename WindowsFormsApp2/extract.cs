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


        public string[] Head { get; private set; }
        public List<string[]> Datasets { get; private set; } = new List<string[]>() ;


        public extract(string _path)
        {
            Path = _path;

            getData();
        }



        public void getData()
        {
            int zeilen, spalten;

            string[] datei = File.ReadAllLines(Path);

            zeilen = datei.Length;
            spalten = datei[0].Split(';').Length;

            for (int zeile = 0; zeile < zeilen; zeile++)
            {
                string[] set = new string[spalten];

                for (int spalte = 0; spalte < spalten; spalte++)
                {
                    set[spalte] = datei[zeile].Split(';')[spalte];
                }

                if (zeile < 1)
                {
                    Head = set;
                }
                else
                {
                    Datasets.Add(set);
                }
            }

        }

    }
}
