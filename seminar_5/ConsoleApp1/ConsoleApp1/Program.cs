using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
             string baseFileName = Path.Combine(
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                "Materiale");

            string dataFileName = baseFileName + "\\students.txt";
            string wordFilePath = baseFileName + "\\students.docx";
            string excelFilePath = baseFileName + "\\students.xlsx";
            string excelTemplateFilePath = baseFileName + "\\studentsTemplate.xlsx";
            string pictureFilePath = baseFileName + "\\sigla.jpg";
                Console.WriteLine(pictureFilePath);


            var students = File.ReadAllLines(dataFileName)
                            .Select(line => new Persoana(line))
                            .OrderByDescending(persoana => persoana.Media)
                            .ThenBy(persoana => persoana.Nume)
                            .ToList();

            students.ForEach(Console.WriteLine);

            var wordApp = new Word.Application() as Word._Application;
            var document = wordApp.Documents.Add();

            document.PageSetup.PaperSize = Word.WdPaperSize.wdPaperA4;

            var headerRanger = document
                                .Sections[1]
                                .Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
                                .Range;

            headerRanger.InlineShapes.AddPicture(pictureFilePath);
            headerRanger.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            var footerRange = document
                                .Sections[1]
                                .Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
                                .Range;

            footerRange.Text = string.Format($"Tiparit la data de: {DateTime.Now.ToString("dd MMMM yyyy", new CultureInfo("ro-ro"))}");
            footerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            var docRange = document.Range();
            docRange.Text = "Lista studenti";
            docRange.set_Style("Heading 1");

            docRange.Font.Color = Word.WdColor.wdColorAqua;
            docRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            docRange.InsertParagraphAfter();
            docRange.InsertParagraphAfter();
            docRange.Collapse(Word.WdCollapseDirection.wdCollapseEnd);

            var table = document.Tables.Add(docRange, students.Count + 1, 3);
            table.Cell(1, 1).Range.Text = "Nr.";
            table.Cell(1, 2).Range.Text = "Nume";
            table.Cell(1, 3).Range.Text = "Medie";

            for (int i = 0; i < students.Count; ++i)
            {
                table.Cell(i + 2, 1).Range.Text = (i + 1).ToString();
                table.Cell(i + 2, 2).Range.Text = students[i].Nume;
                table.Cell(i + 2, 3).Range.Text = students[i].Media.ToString("0.00");

                table.Cell(i + 2, 1).Range.ParagraphFormat.Alignment
                    = Word.WdParagraphAlignment.wdAlignParagraphRight;

                table.Cell(i + 2, 2).Range.ParagraphFormat.Alignment
                    = Word.WdParagraphAlignment.wdAlignParagraphLeft;

                table.Cell(i + 2, 3).Range.ParagraphFormat.Alignment
                    = Word.WdParagraphAlignment.wdAlignParagraphRight;
            }

            table.set_Style("Table professional");
            table.Columns.AutoFit();
            table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);

            document.SaveAs(wordFilePath);
            wordApp.Quit();
            System.Diagnostics.Process.Start(wordFilePath);


            var excelApp = new Excel.Application() as Excel._Application;
            var workBook = excelApp.Workbooks.Open(excelTemplateFilePath);

            Excel.Worksheet sheetData = workBook.Sheets[2];

            var dataRange = sheetData.get_Range("A2");
            dataRange.Value2 = 1;
            dataRange.AutoFill(sheetData.get_Range("A2", "A" + (students.Count + 1)),
                                Excel.XlAutoFillType.xlFillSeries);

            for (int i = 0; i < students.Count; ++i)
            {
                (sheetData.Cells[i + 2, 2] as Excel.Range).Value2 = students[i].Nume;
                (sheetData.Cells[i + 2, 3] as Excel.Range).Value2 = students[i].Media;
            }

            sheetData.get_Range("C2", "C" + (students.Count + 1)).Name = "Valori";
            excelApp.DisplayAlerts = false;

            workBook.Close(SaveChanges: true, Filename: excelFilePath);
            excelApp.Quit();
            System.Diagnostics.Process.Start(excelFilePath);
        }
    }
}
