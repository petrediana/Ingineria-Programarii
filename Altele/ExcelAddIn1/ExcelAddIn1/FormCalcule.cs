using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelAddIn1
{
    public partial class FormCalcule : Form
    {
        private Excel.Worksheet currentSheet = null;

        public FormCalcule()
        {
            InitializeComponent();
            TopMost = true;

            if (Globals.ThisAddIn.Application.ActiveSheet != null)
            {
                currentSheet = Globals.ThisAddIn.Application.ActiveSheet;
                currentSheet.SelectionChange += CurrentSheet_SelectionChange;
                lblTitlu.Text = currentSheet.Name;
            }

            Globals.ThisAddIn.Application.SheetDeactivate += Application_SheetDeactivate;
            Globals.ThisAddIn.Application.SheetActivate += Application_SheetActivate;
        }

        private void Application_SheetActivate(object Sh)
        {
            currentSheet = Sh as Excel.Worksheet;
            currentSheet.SelectionChange += CurrentSheet_SelectionChange;
            lblTitlu.Text = currentSheet.Name;
        }

        private void Application_SheetDeactivate(object Sh)
        {
            if (currentSheet !=  null)
            {
                currentSheet.SelectionChange -= CurrentSheet_SelectionChange;
            }

            lblTitlu.Text = "---";
        }


        private void CurrentSheet_SelectionChange(Excel.Range Target)
        {
            StringBuilder sb = new StringBuilder();

            int n = Target.Rows.Count;
            int m = Target.Columns.Count;

            for (int i = 1; i <= n; ++i)
            {
                for (int j = 1; j <= m; ++j)
                {
                    Excel.Range cell = Target.Cells[i, j] as Excel.Range;
                    if (cell.Value2 != null)
                    {
                        sb.Append(cell.Value2.ToString());
                        sb.Append("   ");
                    }
                }
                sb.AppendLine();
            }

            sb.Insert(0, $"Sunt selectate {n} linii si {m} coloane {Environment.NewLine}");
            tbRez.Text = sb.ToString();
        }
    }
}
