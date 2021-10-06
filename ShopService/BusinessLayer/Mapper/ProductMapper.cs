using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using NotFightClub_Logic.Interfaces;
using System.Collections.Generic;

namespace NotFightClub_Logic.Mappers
{
    public class ProductMapper : IMapper<Product, ViewProduct>
    {

      
        public Product ViewModelToModel(ViewProduct obj)
        {
            Product product = new Product();
            product.ProductId = obj.ProductId;
            product.ProductName = obj.ProductName;
            product.ProductPrice = obj.ProductPrice;
            //product.Seasonal = obj.Seasonal;
            product.SeasonalId = obj.SeasonalId;
            product.ProductDiscount = obj.ProductDiscount;
            //product.UserProducts = obj.UserProducts;

            return product;
        }

        public ViewProduct ModelToViewModel(Product obj)
        {
            ViewProduct viewProduct = new ViewProduct();
            viewProduct.ProductId = obj.ProductId;
            viewProduct.ProductName = obj.ProductName;
            viewProduct.ProductPrice = obj.ProductPrice;
            viewProduct.Seasonal = obj.Seasonal;
            viewProduct.SeasonalId = obj.SeasonalId;
            viewProduct.ProductDiscount = obj.ProductDiscount;
            //viewProduct.UserProducts = obj.UserProducts;

            return viewProduct;
        }

        public List<Product> ViewModelToModel(List<ViewProduct> obj)
        {
            List<Product> products = new List<Product>(obj.Count);
            for (int i = 0; i < obj.Count; i++)
            {
                products[i].ProductId= obj[i].ProductId;
                products[i].ProductDiscount = obj[i].ProductDiscount;
                products[i].ProductName = obj[i].ProductName;
                products[i].ProductPrice = obj[i].ProductPrice;
                products[i].ProductDescription = obj[i].ProductDescription;
                products[i].Seasonal = obj[i].Seasonal;
                products[i].SeasonalId = obj[i].SeasonalId;
               // products[i].UserProducts
            }

            return products;

        }

        public List<ViewProduct> ModelToViewModel(List<Product> obj)
        {
            List<ViewProduct> viewProduct = new List<ViewProduct>(obj.Count);
            for (int i = 0; i < obj.Count; i++)
            {
                viewProduct[i].ProductId = obj[i].ProductId;
                viewProduct[i].ProductName = obj[i].ProductName;
                viewProduct[i].ProductPrice = obj[i].ProductPrice;
                viewProduct[i].Seasonal = obj[i].Seasonal;
                viewProduct[i].SeasonalId = obj[i].SeasonalId;
                viewProduct[i].ProductDiscount = obj[i].ProductDiscount;
                //viewProduct.UserProducts = obj.UserProducts;
            }

            return viewProduct;
        }
    }
}
