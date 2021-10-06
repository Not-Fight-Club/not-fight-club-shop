using BusinessLayer.Interface;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using System.Collections.Generic;


namespace BusinessLayer.Mapper
{
    public class UserProductMapper : IMapper<UserProduct, ViewUserProduct>
  {
    public ViewUserProduct ModelToViewModel(UserProduct userProduct)
    {
      ViewUserProduct viewUserProduct = new ViewUserProduct();
      viewUserProduct.UserProductId = userProduct.UserProductId;
      viewUserProduct.UserId = userProduct.UserId;
      viewUserProduct.ProductId = userProduct.ProductId;
      viewUserProduct.Product = userProduct.Product;

      return viewUserProduct;
    }

    public UserProduct ViewModelToModel(ViewUserProduct viewUserProduct)
    {
      UserProduct userProduct = new UserProduct();
      userProduct.UserProductId = viewUserProduct.UserProductId;
      userProduct.UserId = viewUserProduct.UserId;
      userProduct.ProductId = viewUserProduct.ProductId;
      userProduct.Product = viewUserProduct.Product;

      return userProduct;
    }

    public List<ViewUserProduct> ModelToViewModel(List<UserProduct> obj)
    {
      List<ViewUserProduct> userProducts = new List<ViewUserProduct>();
      for (int i = 0; i < obj.Count; i++)
      {
        ViewUserProduct p = new ViewUserProduct();
        p.UserProductId = obj[i].UserProductId;
        p.UserId = obj[i].UserId;
        p.ProductId = obj[i].ProductId;
        p.Product = obj[i].Product;
        userProducts.Add(p);

      }
      return userProducts;
    }

    public List<UserProduct> ViewModelToModel(List<ViewUserProduct> obj)
    {
      List<UserProduct> userProducts = new List<UserProduct>();
      for (int i = 0; i < obj.Count; i++)
      {
        userProducts.Add(new UserProduct());
        userProducts[i].UserProductId = obj[i].UserProductId;
        userProducts[i].UserId = obj[i].UserId;
        userProducts[i].ProductId = obj[i].ProductId;
        userProducts[i].Product = obj[i].Product;

      }
      return userProducts;
    }
  }

}