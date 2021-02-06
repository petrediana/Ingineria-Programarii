using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflClassLibrary
{
    public class Produs
    {
        private string _denumire;
        private float _pret;

        public Produs()
        {
            _denumire = "necunoscuta";
            _pret = 0.0f;
        }

        public Produs(string denumire, float pret)
        {
            _denumire = denumire;
            _pret = pret;
        }

        public string Denumire
        {
            get => _denumire;
            set => _denumire = value;
        }

        public float Pret
        {
            get => _pret;
            set => _pret = value;
        }

        public string AfiseazaProdus()
            => $"Denumire: {_denumire}, la pretul: {_pret}";

        public float CalculeazaRata(int numarAni)
            => _pret / numarAni;
    }
}
