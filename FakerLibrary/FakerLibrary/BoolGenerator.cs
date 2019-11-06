using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGeneratorLibrary;

namespace FakerLibrary
{
    public class BoolGenerator : IGenerator
    {
        public object Generate()
        {
            return true; //RETURN NOT 0 VALUES!   
        }

        public Type GeneratedType()
        {
            return typeof(bool);
        }
    }
}
