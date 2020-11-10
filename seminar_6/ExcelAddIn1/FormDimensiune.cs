using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class FormDimensiune : Form
    {
        public FormDimensiune()
        {
            InitializeComponent();
        }

        public int Dimensiune
        {
            get =>  Math.Max(1, (int)numDimensiune.Value);
        }
    }
}
