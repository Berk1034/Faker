using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGeneratorLibrary;

namespace Faker
{
    public class DateTimeGenerator : IGenerator
    {
        public object Generate()
        {
            Random rnd = new Random();
            DateTime dt = new DateTime(rnd.Next(1, 9999), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(0, 23), rnd.Next(0, 59), rnd.Next(0, 59));
            return dt;
        }

        public Type GeneratedType()
        {
            return typeof(DateTime);
        }
    }
}
