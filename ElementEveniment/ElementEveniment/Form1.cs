using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElementEveniment
{
    public partial class Form1 : Form
    {
        private readonly Element _element;
        public Form1(Element element)
        {
            InitializeComponent();
            labelIstoric.Text = "Istoric:";

            btnModifica.Text = "Modifica numar";
            btnDeschide.Text = "Vezi istoric";

            _element = element;
            _element.ModificareNumarEvent += Modifica_ElementHandler;
        }

        private void Modifica_ElementHandler(int numarNou)
        {
            textBoxIstoric.Text += "Element modificat, noua valoare: " + numarNou + Environment.NewLine;
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            _element.Numar = int.Parse(textBoxNumar.Text);
        }

        private void btnDeschide_Click(object sender, EventArgs e)
        {
            Form2 formularNou = new Form2(_element);
            formularNou.Show();
        }
    }
}
