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


    public static decimal DiscountedCost(decimal productPrice, decimal? productDiscount)
    {
      decimal discountedTotal; //what the total price will be after the discount has been applied
      decimal actualDiscount;//this stores the amount that will be discounted from the purchase price 
      Product p = new Product();


      p.ProductPrice = productPrice;
      p.ProductDiscount = productDiscount;

      if (productDiscount == null)
      {
        return productPrice;
      }
      else
      {
        actualDiscount = productPrice * (decimal)productDiscount;
        discountedTotal = productPrice - actualDiscount;
      }


      return Math.Round(discountedTotal);

    }
  }
}
