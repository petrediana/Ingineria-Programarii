using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void modificaValori(object obiect, Dictionary<string,object> dictionar)
        {
            Type tipObiect = obiect.GetType();
            foreach(FieldInfo camp in tipObiect.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                object value;
                dictionar.TryGetValue(camp.Name, out value);
                camp.SetValue(obiect, value);
            }
        }
        static void showValues(object obiect)
        {
            Type tipObiect = obiect.GetType();
            foreach (FieldInfo camp in tipObiect.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                Console.WriteLine("Denumire camp: {0} | Tip camp: {1} | Valoare camp: {2}", camp.Name, camp.FieldType, camp.GetValue(obiect));
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, object> dictionar = new Dictionary<string, object>();
            dictionar.Add("idPrajitura", 1);
            dictionar.Add("aroma", "cacao");
            dictionar.Add("cantitate", 10);
            dictionar.Add("pret", 35.50);

            Prajitura p = (Prajitura)Activator.CreateInstance(typeof(Prajitura), 3);
            showValues(p);
            modificaValori(p, dictionar);
            showValues(p);
        }
    }
}
