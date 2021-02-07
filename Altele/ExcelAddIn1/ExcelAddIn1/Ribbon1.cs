using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class Ribbon1
    {
        private static object _tm = Type.Missing;

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void btnGenereazaMatrice_Click(object sender, RibbonControlEventArgs e)
        {
            MatriceForm form = new MatriceForm();
            Random random = new Random();

            Excel.Worksheet sheet = Globals.ThisAddIn.Application.ActiveSheet;
            Excel.Range range = Globals.ThisAddIn.Application.ActiveCell;

            if (form.ShowDialog() == DialogResult.OK)
            {
                int row = range.Row;
                int column = range.Column;
                int dimensiune = form.Dimensiune;

                for (int i = 0; i < dimensiune; ++i)
                {
                    for (int j = 0; j < dimensiune; ++j)
                    {
                        (sheet.Cells[row + i, column + j] as Excel.Range).Value2 = random.Next(0, 100);
                    }
                }
            }
        }

        private void btnSumaDiag_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Worksheet sheet = Globals.ThisAddIn.Application.ActiveSheet;
            Excel.Range range = Globals.ThisAddIn.Application.Selection;

            int m = range.Rows.Count;
            int n = range.Rows.Count;

            if (m == n)
            {
                int suma = 0;
                for (int i = 1; i <= n; ++i)
                {
                    try
                    {
                        suma += (range.Cells[i, i]).Value2;
                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        MessageBox.Show("Selectia contine si caractere non numerice!!!", "Selectie gresita",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MessageBox.Show($"Suma: {suma}");
                int a = 0, b = 0;
                string adresa = range.get_Address(_tm, _tm, Excel.XlReferenceStyle.xlR1C1);
                GetCelulaDestinatie(adresa, ref a, ref b);
                MessageBox.Show($"a={a}, b={b}");
                (sheet.Range[sheet.Cells[a, b], sheet.Cells[a, b]] as Excel.Range)
                                    .Value2 = suma;
            }
            else
            {
                MessageBox.Show("Matricea trebuie sa fie patratica!", "Selectie gresita",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetCelulaDestinatie(string adresa, ref int a, ref int b)
        {
            string[] vs = adresa.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string[] snc = vs[1].Split(new char[] { 'R', 'C' }, StringSplitOptions.RemoveEmptyEntries);
            
            a = Convert.ToInt32(snc[0]) + 1;
            b = Convert.ToInt32(snc[1]) + 1;

        }

        private void btnCalcule_Click(object sender, RibbonControlEventArgs e)
        {
            if (!btnCalcule.Checked)
            {
                var calculeForm = btnCalcule.Tag as Form;

                if (calculeForm != null && calculeForm.Visible)
                {
                    calculeForm.Close();
                }
            }
            else
            {
                var calculeForm = new CalculeForm();
                btnCalcule.Tag = calculeForm;
                calculeForm.Show();
            }
        }
    }
}
