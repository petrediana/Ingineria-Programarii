using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Persoana
    {
        public Persoana(string line)
        {
            string[] splittedLine = line.Split(',');
            
            Nume = splittedLine[0].Trim();
            Media = decimal.Parse(splittedLine[1].Trim(), CultureInfo.InvariantCulture);
        }
        public string Nume { get; set; }
        public decimal Media { get; set; }

        public override string ToString()
        {
            return string.Format("{0:20} - {1,4:0.00}", Nume, Media);
        }
    }
}
