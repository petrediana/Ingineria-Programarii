using System;
using System.Drawing;

namespace Seminar_3
{
    public class EventArgsMM : EventArgs
    {
        int _cadruCurent;
        Bitmap _cadruImagine;

        public EventArgsMM(int cadruCurent, Bitmap cadruImagine)
        {
            _cadruCurent = cadruCurent;
            _cadruImagine = cadruImagine;
        }

        public int IndexCadru
        {
            get => _cadruCurent;
        }

        public Bitmap ImagineCadru
        {
            get => _cadruImagine;
        }
    }
}