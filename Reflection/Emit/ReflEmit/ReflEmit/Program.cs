using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace ReflEmit
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
            AssemblyBuilder assemblyBuilder
                = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);

            // Creaza modulul dll
            ModuleBuilder moduleBuilder
                = assemblyBuilder.DefineDynamicModule(assemblyName.Name, assemblyName.Name + ".dll");

            // Creez clasa TipDinamic
            TypeBuilder typeBuilder = moduleBuilder.DefineType("TipDinamic", TypeAttributes.Public);

            // II dau atributele clasei
            FieldBuilder numarField = typeBuilder.DefineField("_numar", typeof(int) ,FieldAttributes.Private);

            // Definesc metoda Produs
            MethodBuilder prodsMethod = typeBuilder.DefineMethod("Produs", MethodAttributes.Public,
                typeof(int), new Type[] { typeof(int) });

            // Continutul metodei produs
            ILGenerator generator = prodsMethod.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_0); // load argument 0 pe stiva
            generator.Emit(OpCodes.Ldfld, numarField);
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(OpCodes.Mul);
            generator.Emit(OpCodes.Ret);

            // Creez proprietatea Numar
            PropertyBuilder numarProperty = typeBuilder.DefineProperty("Numar", PropertyAttributes.None,
                typeof(int), new Type[] {  });

            MethodBuilder setNumar = typeBuilder.DefineMethod("Set_Numar",
                MethodAttributes.PrivateScope | MethodAttributes.HideBySig | MethodAttributes.Public
                | MethodAttributes.SpecialName, typeof(int), new Type[] { typeof(int) });

            ILGenerator setNumarGenerator = setNumar.GetILGenerator();
            setNumarGenerator.Emit(OpCodes.Ldarg_0);
            setNumarGenerator.Emit(OpCodes.Ldarg_1);
            setNumarGenerator.Emit(OpCodes.Stfld, numarField);
            setNumarGenerator.Emit(OpCodes.Ret);

            // Fac legatura
            numarProperty.SetSetMethod(setNumar);

            MethodBuilder getNumar = typeBuilder.DefineMethod("Get_Numar",
                MethodAttributes.PrivateScope | MethodAttributes.HideBySig
                | MethodAttributes.Public | MethodAttributes.SpecialName, typeof(int),
                new Type[] { typeof(int) });

            ILGenerator getNumarGenerator = getNumar.GetILGenerator();
            getNumarGenerator.Emit(OpCodes.Ldarg_0);
            getNumarGenerator.Emit(OpCodes.Ldfld, numarField);
            getNumarGenerator.Emit(OpCodes.Ret);

            numarProperty.SetGetMethod(getNumar);

            // Creez construcotir
            // Ctor 1 param
            ConstructorBuilder ctor1 = typeBuilder.DefineConstructor(MethodAttributes.Public,
                CallingConventions.Standard, new Type[] { typeof(int) });

            ILGenerator ctor1Gen = ctor1.GetILGenerator();
            ctor1Gen.Emit(OpCodes.Ldarg_0);
            ctor1Gen.Emit(OpCodes.Call, typeof(object).GetConstructor(new Type[0]));
            ctor1Gen.Emit(OpCodes.Ldarg_0);
            ctor1Gen.Emit(OpCodes.Ldarg_1);
            ctor1Gen.Emit(OpCodes.Stfld, numarField);
            ctor1Gen.Emit(OpCodes.Ret);

            // Ctor default
            ConstructorBuilder ctorD = typeBuilder.DefineConstructor(MethodAttributes.Public,
                CallingConventions.Standard, new Type[] { });

            ILGenerator ctorDGenerator = ctorD.GetILGenerator();
            ctorDGenerator.Emit(OpCodes.Ldarg_0);
            ctorDGenerator.Emit(OpCodes.Ldc_I4, (int)150);
            ctorDGenerator.Emit(OpCodes.Call, ctor1);
            ctorDGenerator.Emit(OpCodes.Ret);

            // Folosim elementele create
            /*Type tip = typeBuilder.CreateType();
            object tipInstanta = Activator.CreateInstance(tip);
            Console.WriteLine(tipInstanta);*/

            var type2 = typeBuilder.CreateType();
            var tipInstanta2 = Activator.CreateInstance(type2);
            Console.WriteLine(tipInstanta2.GetType());

            var nrField = type2.GetField("_numar", BindingFlags.NonPublic | BindingFlags.Instance);
            nrField.SetValue(tipInstanta2, 741);
            Console.WriteLine(nrField.GetValue(tipInstanta2));

            int rez = (int)type2.InvokeMember("Produs", BindingFlags.DeclaredOnly | BindingFlags.Public |
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod,
                null, tipInstanta2, new object[] { 10 });
            Console.WriteLine(rez);
        }
    }
}
