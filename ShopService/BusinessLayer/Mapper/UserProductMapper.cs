using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using NotFightClub_Logic.Interfaces;
using System.Collections.Generic;

namespace BusinessLayer.Mapper
{
    public class UserProductMapper : IMapper<UserProduct, ViewUserProduct>
    {
        public ViewUserProduct ModelToViewModel(UserProduct obj)
        {
            
            ViewUserProduct product = new ViewUserProduct();
            product.ProductId = obj.ProductId;
            product.Product = obj.Product;
            product.UserProductId = obj.UserProductId;

            return product;
        }

        public List<ViewUserProduct> ModelToViewModel(List<UserProduct> obj)
        {
            List<ViewUserProduct> products = new List<ViewUserProduct>(obj.Count);
            for (int i = 0; i < obj.Count; i++)
            {
                products[i].ProductId = obj[i].ProductId;
                products[i].Product = obj[i].Product;
                products[i].UserProductId = obj[i].UserProductId;
            }

            return products;

        }

        public UserProduct ViewModelToModel(ViewUserProduct obj)
        {
            UserProduct product = new UserProduct();
            product.ProductId = obj.ProductId;
            product.Product= obj.Product;
            product.UserProductId = obj.UserProductId;

            return product;
        }

        public List<UserProduct> ViewModelToModel(List<ViewUserProduct> obj)
        {
            List<UserProduct> products = new List<UserProduct>(obj.Count);
            for (int i = 0; i < obj.Count; i++)
            {
                products[i].ProductId = obj[i].ProductId;
                products[i].Product = obj[i].Product;
                products[i].UserProductId = obj[i].UserProductId;
            }

            return products;
        }
    }
}
