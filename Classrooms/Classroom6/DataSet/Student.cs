using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetPractice
{
    public class Student
    {
        string name;
        string surname;
        string degree;

        public Student(string name, string surname, string degree)
        {
            this.name = name;
            this.surname = surname;
            this.degree = degree;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Degree
        {
            get { return degree; }
            set { degree = value; }
        }


        public override string ToString()
        {
            return string.Format("{1}, {0} from {2}", name, surname, degree);
        }
    }
}
