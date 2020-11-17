using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestReflection
{
    public partial class Form1 : Form
    {
        private Assembly _assembly;
        private string _lang = "EN";
        private string _button1Name = "Button_OK";
        private string _button2Name = "Button_Cancel";
        private string _button3Name = "Button_Close";
        private Bitmap _img;
        private ResourceManager _resourceManager;

        public Form1()
        {
            _assembly = Assembly.Load("TestReflectionClassLibrary");
            _resourceManager = new ResourceManager("TestReflectionClassLibrary.Resource1", _assembly);
            InitializeComponent();
            IncarcaTextControale();
        }

        private void IncarcaTextControale()
        {
            button1.Text = _resourceManager.GetString(_button1Name + "_" + _lang);
            button2.Text = _resourceManager.GetString(_button2Name + "_" + _lang);
            button3.Text = _resourceManager.GetString(_button3Name + "_" + _lang);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var types = _assembly.GetTypes();
            foreach (var type in types)
            {
                var typeInfo = type.GetTypeInfo();
                textBox1.Text += "Tipul: " + type.FullName + " are " + typeInfo.DeclaredProperties.Count()
                                    + " proprietati, " + typeInfo.DeclaredConstructors.Count()
                                    + " constructori, " + typeInfo.DeclaredMethods.Count()
                                    + " metode, " + typeInfo.DeclaredEvents.Count()
                                    + " evenimente \r\n\n";

                MemberInfo[] memberInfos = type.GetMembers();
                foreach (var memberInfo in memberInfos)
                {
                    textBox1.Text += memberInfo.MemberType + " " + memberInfo.Name + "\r\n\n";
                }

                if (type.Name == "Resource1")
                {
                    _img = (Bitmap)_resourceManager.GetObject("IMG1");
                    panel1.BackgroundImage = _img;
                }
            }
        }

        private void EN_Click(object sender, EventArgs e)
        {
            _lang = "EN";
            IncarcaTextControale();
        }

        private void RO_Click(object sender, EventArgs e)
        {
            _lang = "RO";
            IncarcaTextControale();
        }

        private void FR_Click(object sender, EventArgs e)
        {
            _lang = "FR";
            IncarcaTextControale();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Type type = _assembly.GetType("TestReflectionClassLibrary.Produs");
            
            Type[] stringArgumentTypes = new Type[] { };
            ConstructorInfo stringConstructor = type.GetConstructor(stringArgumentTypes);
            object produs = stringConstructor.Invoke(new object[] { });


            MethodInfo method = type.GetMethod("AfiseazaProdus");
            string rezultat = (string)method.Invoke(produs, new object[] { });

            MessageBox.Show(rezultat);
        }
    }
}
