using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACM.BLTest
{
    [TestClass]
    public class CustomerRepoTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            var customerRepo = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins"
            };
            var actual = customerRepo.Retrieve(1);

            Assert.AreEqual(actual.CustomerId, expected.CustomerId);
        }
    }
}
