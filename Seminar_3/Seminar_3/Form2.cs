using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_3
{
    public partial class Form2 : Form
    {
        AnimatieMM _animatie;
        public Form2(AnimatieMM animatie)
        {
            InitializeComponent();
            _animatie = animatie;
            _animatie.SchimbareCadru += new EventHandlerMM(FormularSchimbareCadru);
            _animatie.TerminareAnimatie += new EventHandlerMM(TerminareAnimatie);
        }

        public void TerminareAnimatie(object sender, EventArgsMM e)
        {
            MessageBox.Show("Animatia s-a terminat la cadrul: " + e.IndexCadru);
        }

        private void FormularSchimbareCadru(object sender, EventArgsMM e)
        {
            pictureBox1.Image = e.ImagineCadru;
        }

        private void StopTot_Click(object sender, EventArgs e)
        {
            _animatie.Stop();
        }
    }
}
