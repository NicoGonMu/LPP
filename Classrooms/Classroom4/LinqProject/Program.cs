using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasroom4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            Random rnd = new Random();
            for (int i = 0; i < 12; i++)
            {
                string sex = ((i % 2) == 0) ? "Male" : "Female" ;
                DateTime dt = DateTime.Now;
                dt.AddDays(i);
                dt.AddMonths(i);
                dt.AddYears(i);
                people.Add(new Person(rnd, sex, dt));
            }
            people.Add(new Person(rnd, "Male", null));
            people.Add(new Person(rnd, "Female", null));


            #region "get females"
            var query = from p in people where p.Sex.Equals("Female") select p;
            foreach (var p in query)
            {
                Console.WriteLine(p.ToString());
            }
            #endregion

            #region "older18"
            query = from p in people where (p.Birthdate != null) && (p.Birthdate.Value.AddYears(18) < (DateTime.Now)) select p;
            foreach (var p in query)
            {
                Console.WriteLine(p.ToString());
            }
            #endregion

            #region "older21"
            query = from p in people where (p.Birthdate != null) && (p.Birthdate.Value.AddYears(21) < (DateTime.Now)) select p;                        
            Console.WriteLine("Greater than 21 yo people: " + query.Count());
            #endregion

            #region "oldest"
            query = from p in people where p.Birthdate != null orderby p.Birthdate ascending select p;            
            Console.WriteLine("Oldest person: " + query.First().ToString());
            #endregion

            #region "diff btween oldest and youngest"
            Console.WriteLine("Difference betweeen youngest and oldest person: " + query.Last().Birthdate.Value.Subtract(query.First().Birthdate.Value).ToString());
            #endregion

            #region "average age"
            var q = from p in people where p.Birthdate != null select p;
            var av = q.Average(x => (x.Birthdate.Value.Year - DateTime.Now.Year));
            Console.WriteLine("Average age: " + av);
            #endregion

            #region "average age by sex"
            var touple = from p in people where p.Birthdate != null group p by p.Sex into peopleSex select new { sex = peopleSex.Key, avg = peopleSex.Average(x => (x.Birthdate.Value.Year - DateTime.Now.Year)) };
            foreach (var p in touple)
            {
                Console.WriteLine(string.Format("Average age of sex {0}: {1}", p.sex, p.avg.ToString()));
            }
            #endregion

            #region "sorted male people"
            query = from p in people where p.Sex.Equals("Male") && p.Birthdate != null orderby p.Birthdate ascending select p;
            foreach (var p in query) {
                Console.WriteLine(p.ToString());
            }
            #endregion

            #region "Check dates"
            query = from p in people where (p.Birthdate != null) select p;
            var query2 = from p in people select p;
            Console.WriteLine((query.Count() == query2.Count() ? "All people has birthdate" : "NOT all people has birthdate"));
            #endregion

            Console.WriteLine("Type anything to exit.");
            Console.Read();
        }
    }
}
