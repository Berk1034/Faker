using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class A
    {
        int c;
        bool k;
        List<byte> T;
        public int testint { get; set; }
    }

    public class B
    {
        public C c{get;set;}
    }

    public class C
    {
        public B b{get;set;}
    }

    public class D
    {
        public int a;
        public int b;
        public bool c;
        private List<bool> BoolList;
        public char k;
        public string Name { get; set; }

        public D()
        {
            a = 10;
            b = 2;
        }
        public D(int a, int b, bool c, List<bool> listbool)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            BoolList = listbool;
        }
        public D(int k, int e)
        {
            a = e;
            b = k;
        }
    }

    public class Foo
    {
        int k;
        public InsideTheFoo inside { get; set; }
        public Foo(int a)
        {
            this.k = a;
        }
    }

    public class InsideTheFoo
    {
        int c;
        public Foo foo { get; set; }
        public InsideTheFoo(int k)
        {
            this.c = k;
        }
    }

    public class PrivateConstructor
    {
        int k;
        int e;
        private PrivateConstructor(int a, int b)
        {
            k = a;
            e = b;
        }
    }

    public class TestProperties
    {
        private string Name { get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();
            int t = faker.Create<int>();
            bool b = faker.Create<bool>();
            byte c = faker.Create<byte>();
            float f = faker.Create<float>();
            DateTime dt = faker.Create<DateTime>();
            char ch = faker.Create<char>();
            double d = faker.Create<double>();
            long lng = faker.Create<long>();
            string str = faker.Create<string>();
            List<int> listtest = faker.Create<List<int>>();
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", t, b, c, f, dt, ch, d, lng, str);
            Console.WriteLine();
            for (int i = 0; i < listtest.Count(); i++)
            {
                Console.WriteLine("{0}", listtest[i]);
            }
            Enum en = faker.Create<Enum>();
            D classtest = faker.Create<D>();
            Foo testrecursion = faker.Create<Foo>();
            A classwithnoconstructor = faker.Create<A>();
            B recursive = faker.Create<B>();
            PrivateConstructor pc = faker.Create<PrivateConstructor>();
            TestProperties tp = faker.Create<TestProperties>();
            Console.ReadLine();
        }
    }
}
