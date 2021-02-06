using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;

namespace ReflUtilizare
{
    public partial class Form1 : Form
    {
        private Assembly assembly;
        private ResourceManager resourceManager;
        private string language = "ENG";
        private string buttonOkName = "Buton_OK";
        private string buttonCancelName = "Buton_Show";
        private Bitmap bitmap;

        public Form1()
        {
            assembly = Assembly.Load("ReflClassLibrary");
            resourceManager = new ResourceManager("ReflClassLibrary.Resource1", assembly);

            InitializeComponent();

            IncaracaTextButoane();
            AfiseazaContinutulResursei();
        }

        private void IncaracaTextButoane()
        {
            button1.Text = resourceManager.GetString($"{buttonOkName}_{language}");
            button2.Text = resourceManager.GetString($"{buttonCancelName}_{language}");
        }

        private void AfiseazaContinutulResursei()
        {
            string[] continut = assembly.GetManifestResourceNames();
            listBox.Items.Clear();

            foreach (var resursa in continut)
            {
                listBox.Items.Add(resursa);
                listBox.Items.Add("\n");
            }

            string denumireResursa = "ReflClassLibrary.Resource1";
            Type type = assembly.GetType(denumireResursa);

            foreach (PropertyInfo propertyInfo
                in type.GetProperties(BindingFlags.Static | BindingFlags.NonPublic))
            {
                if (propertyInfo.PropertyType.Name == "String")
                {
                    listBox.Items.Add($"Cheia: {propertyInfo.Name} este de tipul: {propertyInfo.PropertyType.Name}," +
                    $" are valoarea: {resourceManager.GetString(propertyInfo.Name)}");
                }
                else
                {
                    listBox.Items.Add($"Cheia: {propertyInfo.Name}" +
                        $" este de tipul: {propertyInfo.PropertyType.Name}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Type type = assembly.GetType("ReflClassLibrary.Produs");

            /*ConstructorInfo ctorDefault = type.GetConstructor(new Type[] { });
            object produsDefault = ctorDefault.Invoke(new object[] { });

            MethodInfo afisare = type.GetMethod("AfiseazaProdus");
            string rezultat = (string)afisare.Invoke(produsDefault, new object[] { });
            MessageBox.Show($"Produs default si afisat: {rezultat}");*/

            ConstructorInfo ctorDoiParam = type.GetConstructor(new Type[] { typeof(string), typeof(float) });
            object produsConcret = ctorDoiParam.Invoke(new object[] {"casti wireless", 120.99f });

            MethodInfo afisareMetoda = type.GetMethod("AfiseazaProdus");
            string rez = (string)afisareMetoda.Invoke(produsConcret, new object[] { });

            MethodInfo veziRate = type.GetMethod("CalculeazaRata");
            float dePlata = (float)veziRate.Invoke(produsConcret, new object[] { 3 });

            MessageBox.Show($"Produs concret: {rez}, rata pe 3 ani este: {dePlata}");
        }

        private void toolStripBtnEN_Click(object sender, EventArgs e)
        {
            language = "ENG";
            IncaracaTextButoane();
        }

        private void toolStripBtnRO_Click(object sender, EventArgs e)
        {
            language = "RO";
            IncaracaTextButoane();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Type[] types = assembly.GetTypes();
            foreach (var type in types)
            {
                var typeInfo = type.GetTypeInfo();
                textBox.Text += $"Tipul: {type.Name} are {typeInfo.DeclaredProperties.Count()} proprietati, " +
                    $"{typeInfo.DeclaredConstructors.Count()} constructori, " +
                    $"{typeInfo.DeclaredMethods.Count()} metode, " +
                    $"{typeInfo.DeclaredEvents.Count()} evenimente declarate.\r\n\n";

                MemberInfo[] memberInfos = type.GetMembers();
                foreach (var memberInfo in memberInfos)
                {
                    textBox.Text += memberInfo.Name + "  " + memberInfo.MemberType + "\r\n\n";
                }

                if (type.Name == "Resource1")
                {
                    bitmap = (Bitmap)resourceManager.GetObject("Imagine_1");
                    pictureBoxImagine.Image = bitmap;
                }
            }
        }
    }
}
