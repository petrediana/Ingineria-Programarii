using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.Program;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        readonly Element _element;
        public Form1(object formElement)
        {
            InitializeComponent();
            _element = (Element)formElement;
        }

        // Seteaza valoare noua
        private void SeteazaValoareNoua_Click(object sender, EventArgs e)
        {
            _element.ValoareElement = int.Parse(textBox1.Text);
        }

        public void FunctiePeEveniment(int i)
            => textBox2.Text += "Element modificat. Val: " + i + Environment.NewLine;

        // Decupleaza de la eveniment
        private void DecupleazaDeLaEveniment_Click(object sender, EventArgs e)
            => _element.ElementSchimbat -= FunctiePeEveniment;

        // Cupleaza de la eveniment
        private void CupleazaLaEveniment(object sender, EventArgs e)
            => _element.ElementSchimbat += FunctiePeEveniment;

        // Deschide formular nou
        private void DeschideFormular_Click(object sender, EventArgs e)
        {
            Form2 formularNou = new Form2(_element, FunctiePeEveniment);
            formularNou.Show();
        }
    }
}
