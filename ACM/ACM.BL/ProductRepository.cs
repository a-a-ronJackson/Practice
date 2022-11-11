using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class ProductRepository
    {
        public Product Retrieve(int productId)
        {
            Product product = new Product(productId);

            return product;
        }
       // public bool Save(Product product)
        //{
        //    var success = true;
        //    if (product.HasChanges)
        //    {
        //        if (product.IsValid)
        //        {
        //            if (product.IsNew)
        //            {

        //            }
        //            else
        //            {

        //            }
        //        }
        //        else
        //        {
        //            success = false;
        //        }
        //    return true;
        //}
    }
}
