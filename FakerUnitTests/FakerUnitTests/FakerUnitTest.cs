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
        public void ShouldFillListWithDifferentValues()
        {
            List<int> list = faker.Create<List<int>>();
            Assert.IsNotNull(list);
        }
    }
}
