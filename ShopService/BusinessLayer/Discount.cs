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
            decimal discountedTotal; //what the total price will be after the discount has been applied
            decimal actualDiscunt;//this stores the amount that will be discounted from the purchase price 
            Product p = new Product();


            p.ProductPrice = productPrice;
            p.ProductDiscount = productDiscount;

            actualDiscunt = productPrice * productDiscount;
            discountedTotal = productPrice - actualDiscunt;

            return discountedTotal;
        
        }
    }
}
