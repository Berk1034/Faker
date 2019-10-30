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
        public object Generate()
        {
            Random rnd = new Random();
            return (char)rnd.Next(0, 256);
        }

        public Type GeneratedType()
        {
            return typeof(char);
        }
    }
}
