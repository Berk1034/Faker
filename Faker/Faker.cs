using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class Faker
    {
        public T Create<T>()
        {
            if (typeof(T) == typeof(int)){
                IntGenerator intgen = new IntGenerator();
                int test = intgen.Generate();
                return (T)(object)test;
            }
            if (typeof(T) == typeof(bool))
            {
                BoolGenerator boolgen = new BoolGenerator();
                bool test = boolgen.Generate();
                return (T)(object)test;
            }
            else
            {
                return default(T);
            }
        }
    }
}
