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
    public partial class FormStatistici : Form
    {
        Excel.Worksheet _currentSheet = null;
        List<Excel.Workbook> _lista = new List<Excel.Workbook>();

        public FormStatistici()
        {
            InitializeComponent();

            TopMost = true;

            foreach (Excel.Workbook workbook in Globals.ThisAddIn.Application.Workbooks)
            {
                _lista.Add(workbook);
            }
        
            if (Globals.ThisAddIn.Application.ActiveSheet != null)
            {
                _currentSheet = Globals.ThisAddIn.Application.ActiveSheet;
                _currentSheet.SelectionChange += CurrentSheet_SelectionChanged;
                lblTitle.Text = _currentSheet.Name;
            }

            Globals.ThisAddIn.Application.SheetDeactivate += (sh) =>
            {
                if (_currentSheet != null)
                {
                    _currentSheet.SelectionChange -= CurrentSheet_SelectionChanged;
                }

                lblTitle.Text = "-";
            };

            Globals.ThisAddIn.Application.SheetActivate += (sh) => {
                _currentSheet = sh as Excel.Worksheet;
                _currentSheet.SelectionChange += CurrentSheet_SelectionChanged;
                lblTitle.Text = _currentSheet.Name;
            };
        }

        private void CurrentSheet_SelectionChanged(Excel.Range range)
        {
            var stringBuilder = new StringBuilder();
            var total = 0m;

            for (int linie = 1; linie <= range.Cells.Rows.Count; ++linie)
            {
                for (int coloana = 1; coloana <= range.Cells.Columns.Count; ++coloana)
                {
                    var cell = range.Cells[linie, coloana] as Excel.Range;
                    if (cell.Value2 != null)
                    {
                        stringBuilder
                            .Append(cell.Value2.ToString())
                            .Append(" ");

                        try
                        {
                            total += (decimal)cell.Value2;
                        } catch { }
                    }
                }
                stringBuilder.AppendLine();
            }

            stringBuilder
                .Insert(0, "Total: " + total.ToString("0.00") + Environment.NewLine);

            txtStatistici.Text = stringBuilder.ToString();
        }
    }
}
