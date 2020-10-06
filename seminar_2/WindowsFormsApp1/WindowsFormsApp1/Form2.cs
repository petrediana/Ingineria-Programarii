using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.Program;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        readonly Element _element;
        readonly Element.ElementDelegat delegat;
        public Form2(object element, Element.ElementDelegat functiePeEveniment)
        {
            InitializeComponent();
            _element = (Element)element;
            delegat = functiePeEveniment;
        }

        // Cupleaza
        private void Cupleaza_Click(object sender, EventArgs e)
            => _element.ElementSchimbat += delegat;

        private void Decupleaza_Click(object sender, EventArgs e)
            => _element.ElementSchimbat -= delegat;
    }
}
