﻿using System;
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
    public partial class MatriceForm : Form
    {
        public MatriceForm()
        {
            InitializeComponent();
        }

        public int Dimensiune
        {
            get => (int)Math.Max(2, numDimensiune.Value);
        }
    }
}