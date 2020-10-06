using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Persoana: IComparable, IFormattable
    {
        private string _nume;
        private int _varsta;

        public Persoana(string nume, int varsta)
        {
            _nume = nume;
            _varsta = varsta;
        }
        
        public string Nume
        {
            get => _nume;
            set { _nume = value; }
        }

        public int Varsta
        {
            get => _varsta;
            set 
            { 
                if (value > 0)
                    _varsta = value; 
            }
        }

        public int CompareTo(object obj)
        {
            Persoana local = (Persoana)obj;
            return Varsta.CompareTo(local.Varsta);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (formatProvider == null)
            {
                formatProvider = CultureInfo.InvariantCulture;
            }

            if (string.IsNullOrEmpty(format))
            {
                format = "NV";
            }

            switch(format.ToLowerInvariant())
            {
                case "n":
                    return _nume;
                case "v":
                    return _varsta.ToString();
                case "nv":
                    return _nume + " " + _varsta;
                default:
                    throw new FormatException("String de formatare invalid");
            }
        }

        class SomeExample : IEnumerator
        {
            public object Current => throw new NotImplementedException();

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Persoana p1 = new Persoana("nume120", 99);
            Persoana p2 = new Persoana("nume23", 20);
            Persoana p3 = new Persoana("nume2", 70);

            /*Console.WriteLine($"{p1.Nume}, {p2.Varsta}");
            Console.WriteLine("{0:nv}", p2);*/

            List<Persoana> persoanas = new List<Persoana>(new Persoana[]{ p1, p2, p3 });
            persoanas.Sort((pe1, pe2) => pe1.Nume.CompareTo(pe2.Nume));

            persoanas.ForEach(Console.WriteLine);
        }
    }
}
