using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person.NameChanged += eventHandler;
                Person p = new Person();
                p.Name = "Nico";                
                p.Name = "Pancuato";

                Console.WriteLine("Type anything to exit");
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private static void eventHandler(Person p, string oldName)
        {
            Console.WriteLine($"Name {oldName} changed to: {p.Name}");
        }
    }
}
