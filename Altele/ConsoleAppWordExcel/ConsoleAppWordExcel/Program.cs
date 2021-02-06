using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Globalization;

namespace ConsoleAppWordExcel
{
    class Program
    {
        static void Main(string[] args)
        {
             var binLocatie = System.Reflection.Assembly.GetExecutingAssembly().Location;
             var bazaLocatie = Path.Combine(Path.GetDirectoryName(binLocatie), "Materiale");

            var fisierTextPath = Path.Combine(bazaLocatie, "students.txt");
            var siglaPath = Path.Combine(bazaLocatie, "sigla.jpg");
            var wordPath = Path.Combine(bazaLocatie, "students.docx");
            var excelTemplatePath = Path.Combine(bazaLocatie, "StudentsTemplate.xlsx");
            var excelPath = Path.Combine(bazaLocatie, "students.xlsx");

            var persoane = File.ReadAllLines(fisierTextPath)
                            .Select(line => new Persoana(line))
                            .OrderByDescending(persoana => persoana.Medie)
                            .ThenBy(persoana => persoana.Nume)
                            .ToList();

            persoane.ForEach(Console.WriteLine);

            var wordApp = new Word.Application();
            var wordDocument = wordApp.Documents.Add();

            wordDocument.PageSetup.PaperSize = Word.WdPaperSize.wdPaperA4;

            var headerRange = wordDocument.Sections[1]
                    .Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            headerRange.InlineShapes.AddPicture(siglaPath);
            headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            var footerRange = wordDocument.Sections[1]
                    .Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            footerRange.Text = $"Document tiparit la data de: {DateTime.Now}";
            footerRange.Font.Italic = 1;
            footerRange.HighlightColorIndex = Word.WdColorIndex.wdDarkYellow;
            footerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            var wordRange = wordDocument.Range();
            wordRange.Text = "Lista de studenti";
            wordRange.set_Style("Heading 1");
            wordRange.Font.Name = "Times New Roman";
            wordRange.Font.Bold = 1;
            wordRange.Font.Color = Word.WdColor.wdColorAqua;
            wordRange.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            wordRange.InsertParagraphAfter();
            wordRange.InsertParagraphAfter();
            wordRange.Collapse(Word.WdCollapseDirection.wdCollapseEnd);


            var wordTable = wordDocument.Tables.Add(wordRange, persoane.Count + 1, 3);
            wordTable.Cell(1, 1).Range.Text = "Nr Crt.";
            wordTable.Cell(1, 2).Range.Text = "Nume";
            wordTable.Cell(1, 3).Range.Text = "Media";

            wordTable.Rows[1].Range.Font.Bold = 1;
            wordTable.Rows[1].Range.Font.Italic = 1;

            for (int i = 0; i < persoane.Count; ++i)
            {
                wordTable.Cell(i + 2, 1).Range.Text = (i + 1).ToString();
                wordTable.Cell(i + 2, 1).Range.ParagraphFormat.Alignment
                    = Word.WdParagraphAlignment.wdAlignParagraphRight;

                wordTable.Cell(i + 2, 2).Range.Text = persoane[i].Nume;
                wordTable.Cell(i + 2, 2).Range.ParagraphFormat.Alignment
                    = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                wordTable.Cell(i + 2, 3).Range.Text = (persoane[i].Medie).ToString();
                wordTable.Cell(i + 2, 3).Range.ParagraphFormat.Alignment
                    = Word.WdParagraphAlignment.wdAlignParagraphRight;
            }

            wordTable.set_Style("Table professional");
            wordTable.Columns.AutoFit();
            wordTable.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);

            wordDocument.SaveAs(wordPath);
            wordApp.Quit();
            System.Diagnostics.Process.Start(wordPath);

            /*Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Open(excelTemplatePath);
            Excel.Worksheet excelSheet = excelWorkBook.Sheets[2];

            Excel.Range excelRange = excelSheet.get_Range("A2");
            excelRange.Value2 = 1;
            excelRange.AutoFill(excelSheet.get_Range("A2", $"A{persoane.Count + 1}"),
                                Excel.XlAutoFillType.xlFillSeries);

            for (int i = 0; i < persoane.Count; ++i)
            {
                excelSheet.Cells[i + 2, 2].Value2 = persoane[i].Nume;
                excelSheet.Cells[i + 2, 3].Value2 = persoane[i].Medie;
            }

            excelSheet.get_Range("C2", $"C{persoane.Count + 1}").Name = "Valori";
            excelApp.DisplayAlerts = false;

            excelWorkBook.Close(SaveChanges: true, Filename: excelPath);
            excelApp.Quit();

            System.Diagnostics.Process.Start(excelPath);*/

        }
    }
}
