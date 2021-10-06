using BusinessLayer.Interface;
using BusinessLayer.Mapper;
using DataLayerDbContext.Models;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using NotFightClub_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repo
{
    public class UserProductRepo : IRepo<ViewUserProduct>
    {
        private readonly ShopDbContext _context = new ShopDbContext();
        private readonly IMapper<UserProduct, ViewUserProduct> _mapper;

        public UserProductRepo(IMapper<UserProduct, ViewUserProduct> mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<ViewUserProduct>> ReadAll(Guid id)
        {

                List<UserProduct> products = await _context.UserProducts.Where(u => u.UserId == id).Include("Product").ToListAsync();

                return _mapper.ModelToViewModel(products);
            
        }
    }
}
