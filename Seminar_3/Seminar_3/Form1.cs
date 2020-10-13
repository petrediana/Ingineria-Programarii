using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_3
{
    public partial class Form1 : Form
    {
        AnimatieMM _animatie;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _animatie = new AnimatieMM(500);
            string cale = Path.Combine(
                    Path.GetDirectoryName(GetType().Assembly.Location),
                    "Pamant"
                );

            for (int i = 1; i <= 15; ++i)
            {
                string caleCompleta = Path.Combine(cale, "c" + i + ".jpg");
                _animatie.AdaugaImagine(caleCompleta);
            }

            _animatie.SchimbareCadru += new EventHandlerMM(FormularSchimbareCadru);
        }

        public void FormularSchimbareCadru(object sender, EventArgsMM e)
        {
            pictureBox1.Image = e.ImagineCadru;
        }

        private void Play_Click(object sender, EventArgs e)
        {
            _animatie.Play();
        }

        private void DeschideFormular_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(_animatie);
            form2.Show();
        }
    }
}
