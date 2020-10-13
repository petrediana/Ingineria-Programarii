using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_3
{
    public delegate void EventHandlerMM(object sender, EventArgsMM e);

    public class AnimatieMM
    {
        ArrayList _vectorImagini = new ArrayList();
        int _imagineCurenta;
        Timer _timer;

        public AnimatieMM(int interval)
        {
            _timer = new Timer
            {
                Interval = interval
            };
            _timer.Tick += new EventHandler(Actiune);
        }

        public event EventHandlerMM SchimbareCadru;
        public event EventHandlerMM TerminareAnimatie;

        private void Actiune(object sender, EventArgs e)
        {
            SchimbareCadru?.Invoke(this, 
                new EventArgsMM(_imagineCurenta, (Bitmap)_vectorImagini[_imagineCurenta]));
            ++_imagineCurenta;

            if (_imagineCurenta == _vectorImagini.Count)
            {
                _imagineCurenta = 0;
            }
        }

        public void AdaugaImagine(string caleImagine)
        {
            _vectorImagini.Add(new Bitmap(caleImagine));
        }

        public object this[int index]
        {
            get => _vectorImagini[index];
        }

        public void Play()
        {
            _imagineCurenta = 0;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
            TerminareAnimatie?.Invoke(this,
                new EventArgsMM(_imagineCurenta, (Bitmap)_vectorImagini[_imagineCurenta]));
        }
    }
}
