using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Person : IComparable
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Equals("Pancuato"))
                {
                    throw (new TooUglyNameException());
                }
                if (name == value) return;
                string oldName = name;
                name = value;
                if (NameChanged != null) NameChanged(this, oldName);
            }
        }
        DateTime Birthday;

        public delegate void NameChangedEvent (Person p, string oldName);
        static public event NameChangedEvent NameChanged;


        public override bool Equals(object obj)
        {
            Person p2 = (Person)obj;
            return (Name.Equals(p2.Name) && Birthday.Equals(p2.Birthday));
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(Name) + Birthday.Year + Birthday.Month + Birthday.Day;
        }

        public override string ToString()
        {
            return String.Format("{0}, born in {2} {3} of {1}", Name, Birthday.Year, Birthday.Month, Birthday.Day);
        }

        int IComparable.CompareTo(object obj)
        {
            Person p2 = (Person)obj;
            int ret = Name.CompareTo(p2.Name);
            return (ret == 0) ? Birthday.CompareTo(p2.Birthday) : ret;
        }


        public void notifyNameChange(Person p, string oldName)
        {            
            Console.WriteLine($"Name {oldName} changed to: {p.Name}");
        }
       
    }

    public class TooUglyNameException : Exception
    {
        public TooUglyNameException(): base() {}
    }
}
