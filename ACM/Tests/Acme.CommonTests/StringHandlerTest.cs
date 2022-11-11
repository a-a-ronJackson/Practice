using Acme.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Acme.CommonTests
{
    [TestClass]
    public class StringHandlerTest
    {
        [TestMethod]
        public void InsertSpaceTest()
        {
            var sourceString = "AaronJackson";
            var expected = "Aaron Jackson";

            var actual = sourceString.InsertSpaces();


            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertSpaceWithExsistingSpacesTest()
        {
            var sourceString = "Aaron Jackson";
            var expected = "Aaron Jackson";

            var actual = sourceString.InsertSpaces();


            Assert.AreEqual(expected, actual);
        }
    }
}
