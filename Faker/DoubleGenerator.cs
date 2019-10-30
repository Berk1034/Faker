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
        public object Generate()
        {
            Random rnd = new Random();
            return rnd.NextDouble();
        }

        public Type GeneratedType()
        {
            return typeof(double);
        }
    }
}
