using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLib
{
    public static class Common
    {
        public enum Sex { M, F, O };        

        public static string randomStr(int length, Random random)
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }

        public static Sex randomSex(Random random)
        {
            string characters = "MFO";
            return (Sex)characters[(random.Next() % 3)];
        }

        public static int randomYear(Random random)
        {          
            return 1990 + (random.Next() % 30);
        }

        public static int random(Random random)
        {
            return random.Next();
        }
    }

}
