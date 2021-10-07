using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLayer.ViewModels;
using ModelsLayer.Models;
using BusinessLayer.Mapper;
using BusinessLayer.Repo;
using Xunit;
using DataLayerDbContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace TestLayer
{
	public class SeasonalTest
	{
		private static SqliteConnection connection = new SqliteConnection("DataSource=:memory:");
		private static DbContextOptions<ShopDbContext> Options = new DbContextOptionsBuilder<ShopDbContext>()
			.UseSqlite(connection)
			.Options;
		/*private static DbContextOptions<ShopDbContext> Options = new DbContextOptionsBuilder<ShopDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDb")
			.Options;*/

		private static readonly SeasonalMapper _mapper = new SeasonalMapper();
		private readonly SeasonRepo _repo = new SeasonRepo(Options, _mapper);

		private ViewSeasonal viewHalloween = new ViewSeasonal()
		{
			SeasonalId = 1,
			SeasonalName = "Halloween",
			SeasonalStartDate = new DateTime(2021, 10, 25, 00, 00, 00),
			SeasonalEndDate = new DateTime(2021, 11, 01, 00, 00, 00)
		};
		private Seasonal halloween = new Seasonal()
		{
			SeasonalId = 1,
			SeasonalName = "Halloween",
			SeasonalStartDate = new DateTime(2021, 10, 25, 00, 00, 00),
			SeasonalEndDate = new DateTime(2021, 11, 01, 00, 00, 00)
		};
		private ViewSeasonal viewChristmas = new ViewSeasonal()
		{
			SeasonalId = 2,
			SeasonalName = "Christmas",
			SeasonalStartDate = new DateTime(2021, 12, 04, 00, 00, 00),
			SeasonalEndDate = new DateTime(2021, 12, 26, 00, 00, 00)
		};
		private Seasonal christmas = new Seasonal()
		{
			SeasonalId = 2,
			SeasonalName = "Christmas",
			SeasonalStartDate = new DateTime(2021, 12, 04, 00, 00, 00),
			SeasonalEndDate = new DateTime(2021, 12, 26, 00, 00, 00)
		};
		private List<Seasonal> seasonals = new List<Seasonal>();
		private List<ViewSeasonal> viewSeasonals = new List<ViewSeasonal>();

		public SeasonalTest()
		{
			
		}

		[Fact]
		public void CorrectMappingToEF()
		{
			Seasonal seasonalTest = _mapper.ViewModelToModel(viewHalloween);
			Assert.Equal(1, seasonalTest.SeasonalId);
			Assert.Equal("Halloween", seasonalTest.SeasonalName);
			Assert.Equal(new DateTime(2021, 10, 25, 00, 00, 00), seasonalTest.SeasonalStartDate);
			Assert.Equal(new DateTime(2021, 11, 01, 00, 00, 00), seasonalTest.SeasonalEndDate);
		}

		[Fact]
		public void CorrectMappingToView()
		{
			ViewSeasonal viewSeasonalTest = _mapper.ModelToViewModel(halloween);
			Assert.Equal(1, viewSeasonalTest.SeasonalId);
			Assert.Equal("Halloween", viewSeasonalTest.SeasonalName);
			Assert.Equal(new DateTime(2021, 10, 25, 00, 00, 00), viewSeasonalTest.SeasonalStartDate);
			Assert.Equal(new DateTime(2021, 11, 01, 00, 00, 00), viewSeasonalTest.SeasonalEndDate);
		}

		[Fact]
		public void CorrectLength()
		{
			seasonals.Add(halloween);
			seasonals.Add(christmas);
			int seasonalLength = _mapper.ListLength(seasonals);
			Assert.Equal(2, seasonalLength);
		}

		[Fact]
		public void CorrectGroupMappingToEF()
		{
			viewSeasonals.Add(viewHalloween);
			viewSeasonals.Add(viewChristmas);
			List<Seasonal> listTest = _mapper.ViewModelToModel(viewSeasonals);
			Assert.Equal(halloween, listTest[0]);
			Assert.Equal(christmas, listTest[1]);
		}

		[Fact]
		public void CorrectGroupMappingToView()
		{
			seasonals.Add(halloween);
			seasonals.Add(christmas);
			List<ViewSeasonal> listTest = _mapper.ModelToViewModel(seasonals);
			Assert.Equal(viewHalloween, listTest[0]);
			Assert.Equal(viewChristmas, listTest[1]);
		}

		[Fact]
		public async void AddTest()
		{
			connection.Open();
			using (var context = new ShopDbContext(Options))
			{
				context.Database.EnsureDeleted();
				context.Database.EnsureCreated();

			}
			/*var dbContext = new ShopDbContext(Options); 
			ViewSeasonal newSeason = await _repo.Add(viewHalloween);
			Assert.Equal(viewHalloween.SeasonalId, newSeason.SeasonalId);
			Assert.Equal(viewHalloween.SeasonalName, newSeason.SeasonalName);
			Assert.Equal(viewHalloween.SeasonalStartDate, newSeason.SeasonalStartDate);
			Assert.Equal(viewHalloween.SeasonalEndDate, newSeason.SeasonalEndDate);*/
		}
	}
}
