using BusinessLayer.Repo;
using BusinessLayer.Mapper;
using DataLayerDbContext.Models;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ModelsLayer.ViewModels;

namespace TestLayer
{
	public abstract class SeasonRepoTest
	{
		protected SeasonRepoTest(DbContextOptions<ShopDbContext> options, SeasonalMapper mapper)
		{
			Options = options;
			Mapper = mapper;

			Seed();
		}

		protected DbContextOptions<ShopDbContext> Options { get; }
		protected SeasonalMapper Mapper { get;  }

		private void Seed()
		{
			using (var context = new ShopDbContext(Options))
			{
				context.Database.EnsureDeleted();
				context.Database.EnsureCreated();

				var halloween = new Seasonal();
				halloween.SeasonalId = 1;
				halloween.SeasonalName = "Halloween 2021";
				halloween.SeasonalStartDate = new DateTime(2021, 09, 01, 00, 00, 00, DateTimeKind.Utc);
				halloween.SeasonalEndDate = new DateTime(2021, 11, 01, 00, 00, 00, DateTimeKind.Utc);

				var christmas = new Seasonal();
				christmas.SeasonalId = 2;
				christmas.SeasonalName = "Christmas 2021";
				christmas.SeasonalStartDate = new DateTime(2021, 11, 01, 00, 00, 00, DateTimeKind.Utc);
				christmas.SeasonalEndDate = new DateTime(2022, 01, 01, 00, 00, 00, DateTimeKind.Utc);

				context.AddRange(halloween, christmas);

				context.SaveChanges();
			}
		}

		[Fact]
		public void Can_get_seasons()
		{
			using (var context = new ShopDbContext(Options))
			{
				var repo = new SeasonRepo(Mapper);

				List<ViewSeasonal> seasons = repo.Read().Result;

				Assert.Equal(2, seasons.Count);
				Assert.Equal("Halloween 2021", seasons[0].SeasonalName);
				Assert.Equal("Christmas 2021", seasons[1].SeasonalName);
			}
		}

		[Fact]
		public void Can_get_season()
		{
			using(var context = new ShopDbContext(Options))
			{
				var repo = new SeasonRepo(Mapper);
				ViewSeasonal season = repo.Read(1).Result;
				Assert.Equal("Halloween 2021", season.SeasonalName);
			}
		}

		[Fact]
		public void Can_get_season_by_date()
		{
			using (var context = new ShopDbContext(Options))
			{
				var repo = new SeasonDateRepo(Mapper);
				var date = new DateTime(2021, 10, 05, 00, 00, 00, DateTimeKind.Utc);
				ViewSeasonal season = repo.Read(date).Result;
				Assert.Equal("Halloween 2021", season.SeasonalName);
			}
		}

		[Fact]
		public void Can_add_season()
		{
			using (var context = new ShopDbContext(Options))
			{
				var repo = new SeasonRepo(Mapper);
				ViewSeasonal newSeason = new ViewSeasonal();
				newSeason.SeasonalId = 3;
				newSeason.SeasonalName = "Winter 2022";
				newSeason.SeasonalStartDate = new DateTime(2022, 01, 01, 00, 00, 00, DateTimeKind.Utc);
				newSeason.SeasonalEndDate = new DateTime(2022, 03, 01, 00, 00, 00, DateTimeKind.Utc);
				ViewSeasonal season = repo.Add(newSeason).Result;
				Assert.Equal("Winter 2022", season.SeasonalName);
			}
		}

		[Fact]
		public void Can_update_season()
		{
			using (var context = new ShopDbContext(Options))
			{
				var repo = new SeasonRepo(Mapper);
				ViewSeasonal season = repo.Read(2).Result;
				season.SeasonalName = "Holidays 2021";
				ViewSeasonal updatedSeason = repo.Update(season).Result;
				Assert.Equal("Holidays 2021", season.SeasonalName);
			}
		}
	}
}