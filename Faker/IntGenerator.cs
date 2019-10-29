using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class IntGenerator : IGenerator<int>
    {
        public int Generate()
        {
            Random rnd = new Random();
            return rnd.Next(2) == 0 ? rnd.Next(int.MinValue, -1) : rnd.Next(1, int.MaxValue);
        }
    }
}
