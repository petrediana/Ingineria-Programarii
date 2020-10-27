using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
             string baseFileName = Path.Combine(
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                "Materiale\\students");

            string dataFileName = baseFileName + ".txt";
            string wordFilePath = baseFileName + ".docx";
            string excelFilePath = baseFileName + ".xlsx";
            string excelTemplateFilePath = baseFileName + "Template.xlsx";

            var students = File.ReadAllLines(dataFileName)
                            .Select(line => new Persoana(line))
                            .OrderByDescending(persoana => persoana.Media)
                            .ThenBy(persoana => persoana.Nume)
                            .ToList();

            students.ForEach(Console.WriteLine);
        }
    }
}
