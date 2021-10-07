using System;
using System.Collections.Generic;


#nullable disable

namespace ModelsLayer.ViewModels
{

  public class ViewUserProduct
  {
    public ViewUserProduct() { }
    public ViewUserProduct(int userProductId, Guid? userId, int productId)
    {
      UserProductId = userProductId;
      UserId = userId;
      ProductId = productId;
    }

    public int UserProductId { get; set; }
    public Guid? UserId { get; set; }
    public int ProductId { get; set; }

    // public virtual Product Product { get; set; }
  }
}
