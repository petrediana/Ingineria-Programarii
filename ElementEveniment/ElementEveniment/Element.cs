using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementEveniment
{
    public class Element
    {
        private int _numar;
        public delegate void DelegatElement(int numarNou);
        public event DelegatElement ModificareNumarEvent;

        public Element()
        {
            _numar = 0;
        }

        public int Numar
        {
            get => _numar;
            set
            {
                if (_numar != value)
                {
                    _numar = value;
                    ModificareNumarEvent?.Invoke(_numar);
                }
            }
        }

    }
}
