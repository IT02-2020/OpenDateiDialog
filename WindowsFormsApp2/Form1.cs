using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<person> Personen = new List<person>();

        private void button1_Click(object sender, EventArgs e)
        {
            string benutzerName = Environment.UserName;

            //ab hier in einem PAP oder Struktogramm darstellen
            this.openFileDialog1.InitialDirectory = $"C:\\Users\\{benutzerName}\\Desktop"; //Bitte anpassen
            this.openFileDialog1.Filter = "Excel-Dateien|*.csv";
            this.openFileDialog1.FileName = "";

            bool datei_gewaehlt=false;

            while (!datei_gewaehlt)
            {
                if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    textBox1.Text = this.openFileDialog1.FileName;
                    datei_gewaehlt = true;

                }
                else
                {

                    textBox1.Text = "try again";

                }

                extract E = new extract (this.openFileDialog1.FileName);

                dataGridView1.ColumnCount = E.Head.Length;
                for (int i = 0; i < E.Head.Length; i++)
                {
                    dataGridView1.Columns[i].Name = E.Head[i];
                }
                for (int zeile = 0; zeile < E.Datasets.Count; zeile++)
                {
                    dataGridView1.Rows.Add(E.Datasets[zeile]);
                }


            }
            
        }
    }
}
