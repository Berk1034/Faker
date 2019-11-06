using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGeneratorLibrary;

namespace Faker
{
    public class DoubleGenerator : IGenerator
    {
        private Random rnd = new Random();

        public object Generate()
        {
            return rnd.NextDouble();
        }

        public Type GeneratedType()
        {
            return typeof(double);
        }
    }
}
