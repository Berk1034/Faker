using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGeneratorLibrary;

namespace Faker
{
    public class StringGenerator : IGenerator
    {
        private Random rnd = new Random();

        public object Generate()
        {
            int length = rnd.Next(1, 23);
            string result = "";
            for(int i = 0; i < length; i++)
            {
                result += (char)rnd.Next(0, 256);
            }
            return result;
        }

        public Type GeneratedType()
        {
            return typeof(string);
        }
    }
}
