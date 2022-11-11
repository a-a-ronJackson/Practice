using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class OrderRepository
    {
        public Order Retrieve(int orderId)
        {
            Order Order = new Order(orderId);

            return Order;
        }
        public bool Save(Order order)
        {
            return true;
        }
    }
}
