using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGeneratorLibrary;

namespace FakerLibrary
{
    public class IntGenerator : IGenerator
    {
        public object Generate()
        {
            Random rnd = new Random();
            return rnd.Next(2) == 0 ? rnd.Next(int.MinValue, -1) : rnd.Next(1, int.MaxValue);
        }

        public Type GeneratedType()
        {
            return typeof(int);
        }
    }
}
