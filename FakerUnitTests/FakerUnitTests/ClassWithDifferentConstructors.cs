using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerUnitTests
{
    public class ClassWithDifferentConstructors
    {
        public int a;
        public bool b { get; set; }
        private float f;
        public ClassWithDifferentConstructors(int a, bool b)
        {
            this.a = a;
            this.b = b;
        }
        public ClassWithDifferentConstructors(bool b)
        {
            this.b = b;
        }
    }
}
