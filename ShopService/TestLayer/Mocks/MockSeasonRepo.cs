using BusinessLayer.Interface;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer.Mocks
{
	public class MockSeasonRepo : IRepo<ViewSeasonal, int>
	{
		private readonly List<Seasonal> _seasons = new List<Seasonal>();
		public IQueryable<Seasonal> Seasons => _seasons.AsQueryable();
		private readonly IMapper<Seasonal, ViewSeasonal> _mapper;
		public MockSeasonRepo(IMapper<Seasonal, ViewSeasonal> mapper)
		{
			_mapper = mapper;
		}

		public Task<ViewSeasonal> Add(ViewSeasonal season)
		{
			/*Seasonal dbSeason = _mapper.ViewModelToModel(season);
			_seasons.Add(dbSeason);
			Seasonal newSeason = Seasons.OrderByDescending(x => x.SeasonalId).FirstOrDefault();
			return _mapper.ModelToViewModel(newSeason);*/
			throw new NotImplementedException();
		}

		public Task<ViewSeasonal> Read(int obj)
		{
			throw new NotImplementedException();
		}

		public Task<List<ViewSeasonal>> Read()
		{
			throw new NotImplementedException();
		}

		public List<ViewSeasonal> ReadAll(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<ViewSeasonal> Update(ViewSeasonal obj)
		{
			throw new NotImplementedException();
		}
	}
}
