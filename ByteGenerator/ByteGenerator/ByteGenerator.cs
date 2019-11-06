using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGeneratorLibrary;

namespace ByteGenerator
{
    public class ByteGenerator : IGenerator
    {
        private Random rnd = new Random();

        public object Generate()
        {
            return (byte)rnd.Next(1, byte.MaxValue);
        }

        public Type GeneratedType()
        {
            return typeof(byte);
        }
    }
}
