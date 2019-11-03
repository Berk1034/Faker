using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGeneratorLibrary;

namespace FakerLibrary
{
    public class StringGenerator : IGenerator
    {
        public object Generate()
        {
            Random rnd = new Random();
            int length = rnd.Next(1, 23);
            string result = "";
            for (int i = 0; i < length; i++)
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
