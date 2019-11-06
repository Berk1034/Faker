using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerLibrary;
using System.Collections.Generic;

namespace FakerUnitTests
{
    [TestClass]
    public class FakerUnitTest
    {
        private readonly Faker faker = new Faker();

        [TestMethod]
        public void ShouldFillIntWithNotDefaultValue()
        {
            int TestInt = faker.Create<int>();
            Assert.AreNotEqual(default(int), TestInt);
        }

        [TestMethod]
        public void ShouldFillBoolWithNotDefaultValue()
        {
            bool TestBool = faker.Create<bool>();
            Assert.AreNotEqual(default(bool), TestBool);
        }

        [TestMethod]
        public void ShouldFillCharWithNotDefaultValue()
        {
            char TestChar = faker.Create<char>();
            Assert.AreNotEqual(default(char), TestChar);
        }

        [TestMethod]
        public void ShouldFillDateTimeWithNotDefaultValue()
        {
            DateTime TestDateTime = faker.Create<DateTime>();
            Assert.AreNotEqual(default(DateTime), TestDateTime);
        }

        [TestMethod]
        public void ShouldFillDoubleWithNotDefaultValue()
        {
            double TestDouble = faker.Create<double>();
            Assert.AreNotEqual(default(double), TestDouble);
        }

        [TestMethod]
        public void ShouldFillLongWithNotDefaultValue()
        {
            long TestLong = faker.Create<long>();
            Assert.AreNotEqual(default(long), TestLong);
        }

        [TestMethod]
        public void ShouldFillStringWithNotDefaultValue()
        {
            string TestString = faker.Create<string>();
            Assert.AreNotEqual(default(string), TestString);
        }

        [TestMethod]
        public void ShouldFillByteWithNotDefaultValue()
        {
            byte TestByte = faker.Create<byte>();
            Assert.AreNotEqual(default(byte), TestByte);
        }

        [TestMethod]
        public void ShouldFillFloatWithNotDefaultValue()
        {
            float TestFloat = faker.Create<float>();
            Assert.AreNotEqual(default(float), TestFloat);
        }

        [TestMethod]
        public void ShouldFillListWithDifferentValues()
        {
            List<int> list = faker.Create<List<int>>();
            Assert.IsNotNull(list);
            if (list.Count > 1)
            {
                Assert.AreNotEqual(list[0], list[1]);
            }
        }

        [TestMethod]
        public void ShouldAvoidRecursion()
        {
            A a = faker.Create<A>();
            Assert.IsNotNull(a);
            Assert.IsNotNull(a.inA);
            Assert.IsNotNull(a.inA.inB);
            Assert.IsNull(a.inA.inB.inC);
        }

        [TestMethod]
        public void ShouldReturnNullToNoPublicConstructors()
        {
            ClassWithNoPublicConstructors noPublicConstructors = faker.Create<ClassWithNoPublicConstructors>();
            Assert.IsNull(noPublicConstructors);
        }

        [TestMethod]
        public void ShouldFillObjectWithNotADefaultValuesAndAvoidRecursion()
        {
            Foo foo = faker.Create<Foo>();
            Assert.IsNotNull(foo.bar);
            Assert.IsNull(foo.bar.foo);
            Assert.AreNotEqual(default(int), foo.bar.a);
        }

        [TestMethod]
        public void ShouldFillObjectWithMaxConstructor()
        {
            ClassWithDifferentConstructors differentConstructors = faker.Create<ClassWithDifferentConstructors>();
            Assert.IsNotNull(differentConstructors);
            Assert.AreNotEqual(default(int), differentConstructors.a);
            Assert.AreNotEqual(default(bool), differentConstructors.b);
        }
    }
}
