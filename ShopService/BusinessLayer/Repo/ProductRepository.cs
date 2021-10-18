using Microsoft.EntityFrameworkCore;
using BusinessLayer.Interface;
using DataLayerDbContext.Models;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BusinessLayer.Repo
{
  public class ProductRepository : IRepo<ViewProduct, int>
  {
    private readonly ShopDbContext _dbContext = new ShopDbContext();

    private readonly IMapper<Product, ViewProduct> _mapper;

    public ProductRepository(IMapper<Product, ViewProduct> mapper)
    {
      _mapper = mapper;
    }

    public async Task<ViewProduct> Add(ViewProduct viewProduct)
    {
      Product product = _mapper.ViewModelToModel(viewProduct);

      _dbContext.Database.ExecuteSqlInterpolated($"Insert into Product(SeasonalId, ProductName, ProductPrice, ProductDescription, ProductDiscount) values({product.SeasonalId},{product.ProductName},{product.ProductPrice},{product.ProductDescription},{product.ProductDiscount})");
      _dbContext.SaveChanges();

      Product newProduct = await _dbContext.Products.FromSqlInterpolated($"select * from Product where ProductName = {product.ProductName}").FirstOrDefaultAsync();
      return _mapper.ModelToViewModel(newProduct);
    }

    public async Task<ViewProduct> Read(int id)
    {
      Product product = await _dbContext.Products.FromSqlInterpolated($"select * from Product where ProductId = {id}").FirstOrDefaultAsync();

      return _mapper.ModelToViewModel(product);
    }

    public async Task<List<ViewProduct>> ReadFromSeason(int seasonId)
    {
      List<Product> products = await _dbContext.Products.FromSqlInterpolated($"SELECT * FROM Product WHERE SeasonalId = {seasonId}").ToListAsync();
      List<ViewProduct> viewProducts = _mapper.ModelToViewModel(products);
      return viewProducts;
    }


    public async Task<List<ViewProduct>> Read()
    {
      List<Product> products = await _dbContext.Products.ToListAsync();
      return _mapper.ModelToViewModel(products);
    }

    public Task<ViewProduct> ReadUser(Guid id)
    {
      throw new NotImplementedException();
    }
    public Task<List<ViewProduct>> ReadAll(Guid id)
    {
      throw new NotImplementedException();
    }


    public Task<ViewProduct> Update(ViewProduct obj)
    {
      throw new NotImplementedException();
    }
  }// Eoc
}//EoN