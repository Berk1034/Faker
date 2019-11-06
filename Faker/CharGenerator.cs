using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGeneratorLibrary;

namespace Faker
{
    public class CharGenerator : IGenerator
    {
        private Random rnd = new Random();

        public object Generate()
        {
            return (char)rnd.Next(0, 256);
        }

        public Type GeneratedType()
        {
            return typeof(char);
        }
    }
}
