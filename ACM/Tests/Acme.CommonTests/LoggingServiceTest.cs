using Acme.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ACM.BL;

namespace Acme.CommonTests
{
    [TestClass]
    public class LoggingServiceTest
    {
        [TestMethod]
        public void WriteToFileTest()
        {
            var changedItems = new List<ILoggable>();

            var customer = new Customer(1)
            {
                EmailAddress = "ajack3786@gmail.com",
                FirstName = "Aaron",
                LastName = "Jackson",
                AddressList = null
            };
            changedItems.Add(customer);

            var product = new Product(2)
            {
                ProductName = "Rake",
                ProductDescription = "Garder Rake with Steel Head",
                CurrentPrice = 6M
            };
            changedItems.Add(product);

            LoggingService.WriteToFile(changedItems);
        }

        
    }
}
