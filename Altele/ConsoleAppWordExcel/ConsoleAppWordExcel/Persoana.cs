using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWordExcel
{
    public class Persoana
    {
        public Persoana(string linieFisier)
        {
            string[] valori = linieFisier.Split(',');
            Nume = valori[0];
            Medie = Decimal.Parse(valori[1].Trim());
        }

        public string Nume { get; set; }
        public decimal Medie { get; set; }

        public override string ToString()
        {
            return string.Format("{0:20} - {1,4:00}", Nume, Medie);
        }
    }
}
