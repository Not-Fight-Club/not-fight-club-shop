using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLayer.ViewModels;
using ModelsLayer.Models;
using BusinessLayer.Mapper;
using BusinessLayer.Interface;
using Xunit;

namespace TestLayer
{
  public class ProductTest
  {
    [Fact]
    public void ModelMappingTest()
    {
      //Arrange
      ViewProduct p = new ViewProduct();
      p.ProductId = 1;
      p.SeasonalId = 1;
      p.ProductName = "Balloon";
      p.ProductPrice = 20;
      p.ProductDescription = "You can hang balloons everywhere";
      p.ProductDiscount = 20;

      IMapper<Product, ViewProduct> _mapper = new ProductMapper();

      //Act
      Product p1 = _mapper.ViewModelToModel(p);

      //Assert
      Assert.Contains("Balloon", p1.ProductName);
      Assert.Equal(1, p1.ProductId);

    }

    [Fact]
    public void ViewModelMappingTest()
    {
      //Arrange
      Product p = new Product();
      p.ProductId = 1;
      p.SeasonalId = 1;
      p.ProductName = "Balloon";
      p.ProductPrice = 20;
      p.ProductDescription = "You can hang balloons everywhere";
      p.ProductDiscount = 20;

      IMapper<Product, ViewProduct> _mapper = new ProductMapper();

      //Act
      ViewProduct p1 = _mapper.ModelToViewModel(p);

      //Assert
      Assert.Contains("Balloon", p1.ProductName);
      Assert.Equal(1, p1.ProductId);
    }

  }
}