using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGeneratorLibrary;

namespace Faker
{
    public class IntGenerator : IGenerator
    {
        private Random rnd = new Random();

        public object Generate()
        {
            return rnd.Next(2) == 0 ? rnd.Next(int.MinValue, -1) : rnd.Next(1, int.MaxValue);
        }

        public Type GeneratedType()
        {
            return typeof(int);
        }
    }
}
