using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReflectionClassLibrary
{
    public class Produs
    {
        private string _denumire;
        private float _greutate;

        public Produs()
        {
            _denumire = "nedefinita";
            _greutate = 10;
        }

        public string Denumire
        {
            get => _denumire;
            set => _denumire = value;
        }

        public float Greutate
        {
            get => _greutate;
            set => _greutate = value;
        }

        public string AfiseazaProdus()
        {
            return _denumire + ", " + _greutate;
        }
    }
}
