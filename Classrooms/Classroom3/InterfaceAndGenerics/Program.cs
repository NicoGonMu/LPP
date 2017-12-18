using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAndGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            #region "Search on a list"

            List<Person> people = new List<Person>();
            people.Add(new Person { Name = "a", Birthday = new DateTime(9999, 12, 31) });
            people.Add(new Person { Name = "b", Birthday = new DateTime(9998, 11, 30) });
            people.Add(new Person { Name = "c", Birthday = new DateTime(9997, 10, 29) });
            people.Add(new Person { Name = "d", Birthday = new DateTime(9996, 9, 28) });
            
            if (people.Contains(new Person { Name = "a", Birthday = new DateTime(9999, 12, 31) }))
            {
                //"Contains()" uses "Equals()", that compares the reference if not ovewritten
                Console.WriteLine("Found");
            }

            #endregion


            #region "Sort"

            people.Sort();
            foreach(Person p in people)
            {
                Console.WriteLine(p.ToString());
            }

            #endregion

            Console.WriteLine("Type anything to exit");
            Console.Read();
        }
        
    }
}
