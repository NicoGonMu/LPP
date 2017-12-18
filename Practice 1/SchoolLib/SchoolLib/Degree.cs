using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLib
{
    public class Degree
    {
        List<Subject> subjects;
        string name;
        string code;


        public Degree(string name)
        {
            this.name = name;
            this.code = Common.randomStr(6, new Random());
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public List<Subject> Subjects
        {
            get { return subjects; }
            set { subjects = value; }
        }

        public Subject Subject(int i)
        {
            return subjects.ElementAt(i);
        }


        public override string ToString()
        {
            return string.Format("{0} - {1}", name, code);
        }
    }
}
