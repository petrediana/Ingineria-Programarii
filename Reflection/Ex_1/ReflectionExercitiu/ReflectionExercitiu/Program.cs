using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReflectionExercitiu
{
    class Program
    {
        static void Main(string[] args)
        {
            Masina masina = new Masina(10)
            {
                campPublicInt = 100
            };
            AfisareValoriCampuri(masina);
            Console.WriteLine("\n-----------------\n");
            AfisareMetode(masina);

            Console.WriteLine("\n-----------------\n");
            ModificareValoareCampPrivat(masina, "_id", 500);
            ModificareValoareCampPrivat(masina, "_denumire", "Denumire modificata");
            Console.WriteLine(masina.ID);
            Console.WriteLine(masina.Denumire);
        }

        static void AfisareValoriCampuri(object obiect)
        {
            // Obtinem obiectul Type
            Type type = obiect.GetType();

            // Enumeram toate campurile, inclusiv cele private
            foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic))
            {
                Console.WriteLine($"Numele: {fieldInfo.Name}\nTipul: {fieldInfo.FieldType}" +
                    $"\nValoarea sa: {fieldInfo.GetValue(obiect)}\n");
            }
        }

        static void AfisareMetode(object obiect)
        {
            // Obtinem obiectul Type
            Type type = obiect.GetType();

            // Enumeram toate metodele publice
            foreach (MethodInfo method in type.GetMethods())
            {
                // Afisam tipul returnat si denumirea metodei
                Console.WriteLine($"Metoda: {method.Name}\nReturneaza: {method.ReturnType.Name}");

                // Afisam tipul si denumirea parametrilor
                foreach (ParameterInfo param in method.GetParameters())
                {
                    Console.WriteLine($"\tTipul parametrului: {param.ParameterType.Name}, " +
                        $"Denumirea parametrului: {param.Name}");
                }
                Console.WriteLine();
            }
        }

        static void ModificareValoareCampPrivat(object obiect, string numeCamp, object valoare)
        {
            // Obtinem obiectul type
            Type type = obiect.GetType();

            // Identificam campul
            FieldInfo camp = type.GetField(numeCamp, BindingFlags.Instance | BindingFlags.NonPublic);

            // Modificam valoarea
            camp.SetValue(obiect, valoare);
        }
    }
}
