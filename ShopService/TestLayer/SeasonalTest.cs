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
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TestLayer
{
	public class SeasonalTest
	{
		private DbContextOptions<ShopDbContext> Options { get; set; } 
		//private static readonly DbConnection _connection = RelationalOptionsExtension.Extract(Options).Connection;
		private static readonly SeasonalMapper _mapper = new SeasonalMapper();
		private ShopDbContext _context;
		private SeasonRepo _repo;

		public static DbConnection CreateInMemoryDatabase()
		{
			var connection = new SqliteConnection("Filename=:memory:");
			connection.Open();
			return connection;
		}

		public SeasonalTest()
		{
			Options = new DbContextOptionsBuilder<ShopDbContext>()
						.UseSqlite(CreateInMemoryDatabase())
						.Options;
			_context = new ShopDbContext(Options);
			_repo = new SeasonRepo(_context, _mapper);
			Seed();
		}

		private void Seed()
		{
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();

			var halloween = new Seasonal();
			halloween.SeasonalName = "Halloween 2021";
			halloween.SeasonalStartDate = new DateTime(2021, 09, 01, 00, 00, 00, DateTimeKind.Utc);
			halloween.SeasonalEndDate = new DateTime(2021, 11, 01, 00, 00, 00, DateTimeKind.Utc);

			var christmas = new Seasonal();
			christmas.SeasonalName = "Christmas 2021";
			christmas.SeasonalStartDate = new DateTime(2021, 11, 01, 00, 00, 00, DateTimeKind.Utc);
			christmas.SeasonalEndDate = new DateTime(2022, 01, 01, 00, 00, 00, DateTimeKind.Utc);

			_context.AddRange(halloween, christmas);

			_context.SaveChanges();
		}

		private ViewSeasonal viewHalloween = new ViewSeasonal()
		{
			SeasonalName = "Halloween",
			SeasonalStartDate = new DateTime(2021, 10, 25, 00, 00, 00, DateTimeKind.Utc),
			SeasonalEndDate = new DateTime(2021, 11, 01, 00, 00, 00, DateTimeKind.Utc)
		};
		private Seasonal halloween = new Seasonal()
		{
			SeasonalName = "Halloween",
			SeasonalStartDate = new DateTime(2021, 10, 25, 00, 00, 00, DateTimeKind.Utc),
			SeasonalEndDate = new DateTime(2021, 11, 01, 00, 00, 00, DateTimeKind.Utc)
		};
		private ViewSeasonal viewChristmas = new ViewSeasonal()
		{
			SeasonalName = "Christmas",
			SeasonalStartDate = new DateTime(2021, 12, 04, 00, 00, 00, DateTimeKind.Utc),
			SeasonalEndDate = new DateTime(2021, 12, 26, 00, 00, 00, DateTimeKind.Utc)
		};
		private Seasonal christmas = new Seasonal()
		{
			SeasonalName = "Christmas",
			SeasonalStartDate = new DateTime(2021, 12, 04, 00, 00, 00, DateTimeKind.Utc),
			SeasonalEndDate = new DateTime(2021, 12, 26, 00, 00, 00, DateTimeKind.Utc)
		};
		private List<Seasonal> seasonals = new List<Seasonal>();
		private List<ViewSeasonal> viewSeasonals = new List<ViewSeasonal>();

		[Fact]
		public void Can_get_seasons()
		{
			List<ViewSeasonal> seasons = _repo.Read().Result;

			Assert.Equal(2, seasons.Count);
			Assert.Equal("Halloween 2021", seasons[0].SeasonalName);
			Assert.Equal("Christmas 2021", seasons[1].SeasonalName);
		}

		[Fact]
		public void Can_get_season()
		{
			var date = new DateTime(2021, 10, 05, 00, 00, 00, DateTimeKind.Utc);
			ViewSeasonal season = _repo.Read(date).Result;
			Assert.Equal("Halloween 2021", season.SeasonalName);
		}

		[Fact]
		public void Can_add_season()
		{
			ViewSeasonal newSeason = new ViewSeasonal();
			newSeason.SeasonalName = "Winter 2022";
			newSeason.SeasonalStartDate = new DateTime(2022, 01, 01, 00, 00, 00, DateTimeKind.Utc);
			newSeason.SeasonalEndDate = new DateTime(2022, 03, 01, 00, 00, 00, DateTimeKind.Utc);
			ViewSeasonal season = _repo.Add(newSeason).Result;
			Assert.Equal("Winter 2022", season.SeasonalName);
		}

		//[Fact]
		//public void Can_update_season()
		//{
		//	var date = new DateTime(2021, 12, 05, 00, 00, 00, DateTimeKind.Utc);
		//	ViewSeasonal season = _repo.Read(date).Result;
		//	season.SeasonalName = "Holidays 2021";
		//	ViewSeasonal updatedSeason = _repo.Update(season).Result;
		//	Assert.Equal("Holidays 2021", updatedSeason.SeasonalName);
		//}

		[Fact]
		public void CorrectMappingToEF()
		{
			Seasonal seasonalTest = _mapper.ViewModelToModel(viewHalloween);
			Assert.Equal("Halloween", seasonalTest.SeasonalName);
			Assert.Equal(new DateTime(2021, 10, 25, 00, 00, 00, DateTimeKind.Utc), seasonalTest.SeasonalStartDate);
			Assert.Equal(new DateTime(2021, 11, 01, 00, 00, 00, DateTimeKind.Utc), seasonalTest.SeasonalEndDate);
		}

		[Fact]
		public void CorrectMappingToView()
		{
			ViewSeasonal viewSeasonalTest = _mapper.ModelToViewModel(halloween);
			Assert.Equal("Halloween", viewSeasonalTest.SeasonalName);
			Assert.Equal(new DateTime(2021, 10, 25, 00, 00, 00, DateTimeKind.Utc), viewSeasonalTest.SeasonalStartDate);
			Assert.Equal(new DateTime(2021, 11, 01, 00, 00, 00, DateTimeKind.Utc), viewSeasonalTest.SeasonalEndDate);
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
			Assert.Equal(halloween.SeasonalName, listTest[0].SeasonalName);
			Assert.Equal(christmas.SeasonalName, listTest[1].SeasonalName);
		}

		[Fact]
		public void CorrectGroupMappingToView()
		{
			seasonals.Add(halloween);
			seasonals.Add(christmas);
			List<ViewSeasonal> listTest = _mapper.ModelToViewModel(seasonals);
			Assert.Equal(viewHalloween.SeasonalName, listTest[0].SeasonalName);
			Assert.Equal(viewChristmas.SeasonalName, listTest[1].SeasonalName);
		}
	}
}
