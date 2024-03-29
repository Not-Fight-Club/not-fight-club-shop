﻿using BusinessLayer.Interface;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using System.Collections.Generic;
using System;

namespace BusinessLayer.Mapper
{
  public class ProductMapper : IMapper<Product, ViewProduct>
  {
    public ViewProduct ModelToViewModel(Product product)
    {
      ViewProduct viewProduct = new ViewProduct();
      viewProduct.ProductId = product.ProductId;
      viewProduct.SeasonalId = product.SeasonalId;
      viewProduct.ProductName = product.ProductName;
      viewProduct.ProductPrice = product.ProductPrice;
      viewProduct.ProductDescription = product.ProductDescription;
      viewProduct.ProductDiscount = product.ProductDiscount;
      viewProduct.CategoryId = product.CategoryId;
            if(product.Category != null)
            {
                viewProduct.Category = product.Category.category;

            }

            return viewProduct;
    }

    public Product ViewModelToModel(ViewProduct viewProduct)
    {
      Product product = new Product();
      product.ProductId = viewProduct.ProductId;
      product.SeasonalId = viewProduct.SeasonalId;
      product.ProductName = viewProduct.ProductName;
      product.ProductPrice = viewProduct.ProductPrice;
      product.ProductDescription = viewProduct.ProductDescription;
      product.ProductDiscount = viewProduct.ProductDiscount;
      product.CategoryId = viewProduct.CategoryId;

            //build a category object to attach to the product
            Category cat = new Category();
            if(viewProduct.CategoryId != null)
            {
                cat.CategoryId = (int)viewProduct.CategoryId;
                cat.category = viewProduct.Category;
                product.Category = cat;
            }
            
           

      return product;
    }

    public List<ViewProduct> ModelToViewModel(List<Product> obj)
    {
      List<ViewProduct> products = new List<ViewProduct>();
      for (int i = 0; i < obj.Count; i++)
      {
        ViewProduct p = new ViewProduct();
        p.ProductId = obj[i].ProductId;
        p.SeasonalId = obj[i].SeasonalId;
        p.ProductName = obj[i].ProductName;
        p.ProductPrice = obj[i].ProductPrice;
        p.ProductDescription = obj[i].ProductDescription;
        p.ProductDiscount = obj[i].ProductDiscount;
        p.CategoryId = obj[i].CategoryId;
        p.Category = obj[i].Category.category;
        products.Add(p);
      }
      return products;
    }

    public List<Product> ViewModelToModel(List<ViewProduct> obj)
    {
      List<Product> products = new List<Product>(obj.Count);
      for (int i = 0; i < obj.Count; i++)
      {
        products[i].ProductId = obj[i].ProductId;
        products[i].SeasonalId = obj[i].SeasonalId;
        products[i].ProductName = obj[i].ProductName;
        products[i].ProductPrice = obj[i].ProductPrice;
        products[i].ProductDescription = obj[i].ProductDescription;
        products[i].ProductDiscount = obj[i].ProductDiscount;
        products[i].CategoryId = obj[i].CategoryId;
      }
      return products;
    }
  }
}