using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class BoolGenerator : IGenerator<bool>
    {
        public bool Generate()
        {
            return true; //RETURN NOT 0 VALUES!   
        }
    }
}
