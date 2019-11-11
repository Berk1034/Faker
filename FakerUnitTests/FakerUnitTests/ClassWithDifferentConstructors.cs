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
        public float publicf { get { return f; } }
        private string str = "I am private";
        public string publicstr { get { return str; } }
        public string str2 = "Hell";
        public string publicstr2 { get { return str2; } }
        public ClassWithDifferentConstructors(int a, bool b)
        {
            this.a = a;
            this.b = b;
        }
        public ClassWithDifferentConstructors(bool b)
        {
            this.b = b;
        }
        private ClassWithDifferentConstructors(int a, bool b, float f, string str)
        {
            this.a = a;
            this.b = b;
            this.f = f;
            this.str = str;
        }
    }
}
