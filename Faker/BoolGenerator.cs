using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGeneratorLibrary;

namespace Faker
{
    public class BoolGenerator : IGenerator
    {
        public Type GeneratedType()
        {
            return typeof(bool);
        }

        public object Generate()
        {
            return true; //RETURN NOT 0 VALUES!   
        }
    }
}
