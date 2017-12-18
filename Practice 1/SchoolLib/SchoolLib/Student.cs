using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLib
{
    public class Student
    {
        string name;
        string surname;
        DateTime birthDate;
        string originSchool;
        Common.Sex sex;

        public Student(string name, string surname, DateTime birthDate, string originSchool, Common.Sex sex) {
            this.name = name;
            this.surname = surname;
            this.originSchool = originSchool;
            this.sex = sex;
            this.birthDate = DateTime.Now;
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string OriginSchool
        {
            get { return originSchool; }
            set { originSchool = value; }
        }

        public DateTime Birthdate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public Common.Sex Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public override string ToString()
        {
            return string.Format("{1}, {0} from {2}, {3} born on {4}", name, surname, originSchool, Convert.ToChar(sex), birthDate.ToString());
        }
    }
}
