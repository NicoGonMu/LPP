using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLib
{
    public class Subject
    {
        static int count = 0;

        string name;
        int code;
        int year; 
        
        public Subject(string name, int year)
        {
            this.name = name;
            this.year = year;
            this.code = ++count;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Code
        {
            get { return code; }
            set { code = value; }
        }
        
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public override string ToString()
        {
            return string.Format("{1} - {0} ({2})", name, code, year.ToString());
        }

        public override bool Equals(object obj)
        {
            Subject sb = (Subject)obj;
            return code == sb.Code;
        }

    }
}
