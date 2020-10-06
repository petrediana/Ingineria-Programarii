using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public static class Program
    {
        public class Element
        {
            int _element;
            public delegate void ElementDelegat(int i);
            public event ElementDelegat ElementSchimbat;
            public int ValoareElement
            {
                get => _element;
                set
                {
                    if (_element != value)
                    {
                        _element = value;

                        // invocam un eveniment
                        ElementSchimbat?.Invoke(_element);
                    }
                }
            }
        }

        class Observator
        {
            public void ObservatorElementSchimbat(int i)
                => Console.WriteLine($"Element schimbat, valoare noua: {i}");
        }
        
        [STAThread]
        static void Main()
        {
            Element element = new Element();
            Form1 formular = new Form1(element);

            element.ElementSchimbat += new Element.ElementDelegat(formular.FunctiePeEveniment);
            element.ValoareElement = 15;

            Observator observator = new Observator();
            element.ElementSchimbat += new Element.ElementDelegat(observator.ObservatorElementSchimbat);

            formular.ShowDialog();

            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(element));*/
        }
    }
}
