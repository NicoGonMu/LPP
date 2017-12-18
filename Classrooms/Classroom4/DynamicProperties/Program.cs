using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            List<dynamic> list = new List<dynamic>();
            dynamic obj = new ExpandoObject();
            obj.Name = "a"; obj.Surname = "b";
            list.Add(obj);

            obj = new ExpandoObject();
            obj.Name = "c"; obj.Surname = "d";
            list.Add(obj);

            obj = new ExpandoObject();
            obj.Name = "e"; obj.Surname = "f";
            list.Add(obj);

            obj = new ExpandoObject();
            obj.Name = "g"; obj.Surname = "h";
            obj.Prueba = 3;
            list.Add(obj);

            var p = from o in list where o.Name.Contains("a") select o;

            foreach(var v in p) Console.WriteLine($"{v.Name}, {v.Surname}");
            Console.WriteLine("Type anything to exit.");
            Console.Read();
        }
    }
}
