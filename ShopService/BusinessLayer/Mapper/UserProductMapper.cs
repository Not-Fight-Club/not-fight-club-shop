using BusinessLayer.Interface;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using NotFightClub_Logic.Interfaces;
using System.Collections.Generic;
using System;


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

      return viewUserProduct;
    }

    public UserProduct ViewModelToModel(ViewUserProduct viewUserProduct)
    {
      UserProduct userProduct = new UserProduct();
      userProduct.UserProductId = viewUserProduct.UserProductId;
      userProduct.UserId = viewUserProduct.UserId;
      userProduct.ProductId = viewUserProduct.ProductId;

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

      }
      return userProducts;
    }

    public List<UserProduct> ViewModelToModel(List<ViewUserProduct> obj)
    {
      List<UserProduct> userProducts = new List<UserProduct>(obj.Count);
      for (int i = 0; i < obj.Count; i++)
      {
        userProducts[i].UserProductId = obj[i].UserProductId;
        userProducts[i].UserId = obj[i].UserId;
        userProducts[i].ProductId = obj[i].ProductId;

      }
      return userProducts;
    }
  }

}