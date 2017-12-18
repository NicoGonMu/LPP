using System;
using System.Reflection;

namespace Ex_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Loaded assemblies
            Assembly[] a = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in a) Console.WriteLine(assembly.FullName);            

            //Dynamic load
            Assembly ex_assembly = AppDomain.CurrentDomain.Load("Ex_Assembly");

            //Get class person information
            Type person = ex_assembly.GetType("Ex_Assembly.Person");
            
            //Create an object invoking Constructor
            ConstructorInfo[] constructors = person.GetConstructors();
            ConstructorInfo constructor = constructors[0];
            ParameterInfo[] parameters = constructor.GetParameters();

            //Get Information about class Person
            Console.WriteLine("Information about class Person");
            foreach (ParameterInfo p in parameters) Console.WriteLine(p.ParameterType + " " + p.Name);            
            var yo = constructor.Invoke(new Object[] { "Nico", new DateTime(1994, 02, 16) });

            //Get information about properties, show the value for any property of the created object
            PropertyInfo[] pInfo = person.GetProperties();
            foreach (PropertyInfo p in pInfo) Console.WriteLine(p.Name + ": " + p.PropertyType.Name);

            //Call ToString method
            MethodInfo toString = person.GetMethod("ToString");
            Console.WriteLine(toString.Invoke(yo, null));

            Console.WriteLine("Type anything to exit");
            Console.Read();
        }
    }
}
