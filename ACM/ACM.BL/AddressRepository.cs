using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class AddressRepository
    {
        public Address Retrieve(int addressId)
        {
            Address Address = new Address(addressId);

            return Address;
        }
        public IEnumerable<Address> RetrieveByCustomerId(int customerId)
        {
            var addressList = new List<Address>();
            //addressList.Add(address);
            return addressList;
        }
        public bool Save(Address address)
        {
            return true;
        }
    }
}
