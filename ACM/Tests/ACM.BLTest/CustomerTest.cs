using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACM.BLTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            Customer customer = new Customer
            {
                FirstName = "Aaron",
                LastName = "Jackson"
            };

            string expected = "Jackson, Aaron";

            string actual = customer.FullName;

            Assert.AreEqual(expected, actual);
        }
        
    }


}
