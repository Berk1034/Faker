using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGeneratorLibrary;

namespace FloatGenerator
{
    public class FloatGenerator : IGenerator
    {
        private Random rnd = new Random();

        public object Generate()
        {
            int sign = rnd.Next(2);
            int exponent = rnd.Next((1 << 8) - 1);
            int mantissa = rnd.Next(1 << 23);
            float bits = (sign << 31) + (exponent << 23) + mantissa;
            return bits;
        }

        public Type GeneratedType()
        {
            return typeof(float);
        }
    }
}
