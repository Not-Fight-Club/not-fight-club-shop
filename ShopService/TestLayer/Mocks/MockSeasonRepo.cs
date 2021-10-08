using BusinessLayer.Repo;
using BusinessLayer.Interface;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerDbContext.Models;
using Microsoft.EntityFrameworkCore;

namespace TestLayer.Mocks
{
	public class MockSeasonRepo : SeasonRepo
	{
		//I want to use a different DBContext instead of the real database, but I don't know which one to use.
		private readonly ShopDbContext _dbContext = new DbContextOptionsBuilder<ShopDbContext>()
			.UseSqlite("Filename=Test.db")
			.Options;
		private readonly IMapper<Seasonal, ViewSeasonal> _mapper;
		public MockSeasonRepo(IMapper<Seasonal, ViewSeasonal> mapper) : base (mapper)
		{
			_mapper = mapper;
		}
	}
}
