using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElementEveniment
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Element element1 = new Element();
            element1.ModificareNumarEvent += Observator.ObservaElementSchimba;

            element1.Numar = 10;
            element1.Numar = 11;

            Form1 formular = new Form1(element1);
            formular.ShowDialog();

            
            /* Application.Run(new Form1());*/
        }
    }
}
