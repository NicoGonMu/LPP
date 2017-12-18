using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasroom4
{
    class Person
    {
        private string name;
        private string sex;
        private DateTime? birthdate;

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public DateTime? Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }


        public Person(Random rnd, string sex, DateTime? birthdate)
        {            
            this.name = randomStr(6, rnd);
            this.sex = sex;
            this.birthdate = birthdate;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}, {2}", name, sex, birthdate.ToString());
        }


        private string randomStr(int length, Random random)
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }
    }
}
