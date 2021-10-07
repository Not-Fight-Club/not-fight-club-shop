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
  public class UserProductRepository : IRepo<ViewUserProduct, int>
  {

    private readonly ShopDbContext _dbContext = new ShopDbContext();

    private readonly IMapper<UserProduct, ViewUserProduct> _mapper;

    public UserProductRepository(IMapper<UserProduct, ViewUserProduct> mapper)
    {
      _mapper = mapper;
    }

    public async Task<ViewUserProduct> Add(ViewUserProduct viewUserProduct)
    {
      UserProduct userProduct = _mapper.ViewModelToModel(viewUserProduct);

      _dbContext.Database.ExecuteSqlInterpolated($"Insert into UserProduct(UserId, ProductId) values({userProduct.UserId},{userProduct.ProductId})");
      _dbContext.SaveChanges();

      UserProduct newUserProduct = await _dbContext.UserProducts.FromSqlInterpolated($"select * from UserProduct where UserId = {userProduct.UserId}").FirstOrDefaultAsync();
      return _mapper.ModelToViewModel(newUserProduct);
    }

    public async Task<ViewUserProduct> Read(int id)
    {
      UserProduct userProduct = await _dbContext.UserProducts.FromSqlInterpolated($"select * from UserProduct where UserProductId = {id}").FirstOrDefaultAsync();

      return _mapper.ModelToViewModel(userProduct);
    }

    public async Task<List<ViewUserProduct>> Read()
    {
      List<UserProduct> userProducts = await _dbContext.UserProducts.ToListAsync();
      return _mapper.ModelToViewModel(userProducts);
    }


    public async Task<List<ViewUserProduct>> ReadAll(Guid id)
    {

        List<UserProduct> products = await _dbContext.UserProducts.Where(u => u.UserId == id).Include("Product").ToListAsync();

        return _mapper.ModelToViewModel(products);

    } 

		public Task<ViewUserProduct> Update(ViewUserProduct obj)
		{
			throw new NotImplementedException();
		}
	}//Eoc
}//EoN