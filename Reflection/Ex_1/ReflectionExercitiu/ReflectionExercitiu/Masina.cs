using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExercitiu
{
    public class Masina
    {
        private int _id;
        private string _denumire;
        private decimal _pret;
        public int campPublicInt;

        public Masina(int id)
        {
            _id = id;
            _denumire = "Necunoscuta";
            _pret = 0.0m;
        }

        public int ID
        {
            get => _id;
        }

        public string Denumire
        {
            get => _denumire;
            set => _denumire = value;
        }

        public decimal Pret
        {
            get => _pret;
            set => _pret = value;
        }

        public string InformatiiMasina()
            => "Informatii masina...";

        public decimal CalculeazaRata(int numarDeAni)
            => Pret / numarDeAni;
    }
}
