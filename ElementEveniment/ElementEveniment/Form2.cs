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
    public partial class Form2 : Form
    {
        private readonly Element _element;
        public Form2(Element element)
        {
            InitializeComponent();
            _element = element;
            _element.ModificareNumarEvent += Afiseaza_Istoric;

        }

        private void Afiseaza_Istoric(int numarNou)
            => textBoxIstoric.Text += $"Element modificat; noua valoare: {numarNou};{Environment.NewLine}";
            
    }
}
