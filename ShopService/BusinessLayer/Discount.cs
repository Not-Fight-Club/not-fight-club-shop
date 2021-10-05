using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLayer.Models;

namespace BusinessLayer
{
    public static class Discount
    {
             
       
        public static decimal DiscountedCost(decimal productPrice, decimal productDiscount)
        {
            decimal discountedTotal;
            Product p = new Product();

            p.ProductPrice = productPrice;
            p.ProductDiscount = productDiscount;

            discountedTotal = productPrice - productDiscount;

            return discountedTotal;
        
        }
    }
}
