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
	public class SeasonalTest : SeasonRepoTest
	{
		private static readonly SeasonalMapper _mapper = new SeasonalMapper();

		private ViewSeasonal viewHalloween = new ViewSeasonal()
		{
			SeasonalId = 1,
			SeasonalName = "Halloween",
			SeasonalStartDate = new DateTime(2021, 10, 25, 00, 00, 00, DateTimeKind.Utc),
			SeasonalEndDate = new DateTime(2021, 11, 01, 00, 00, 00, DateTimeKind.Utc)
		};
		private Seasonal halloween = new Seasonal()
		{
			SeasonalId = 1,
			SeasonalName = "Halloween",
			SeasonalStartDate = new DateTime(2021, 10, 25, 00, 00, 00, DateTimeKind.Utc),
			SeasonalEndDate = new DateTime(2021, 11, 01, 00, 00, 00, DateTimeKind.Utc)
		};
		private ViewSeasonal viewChristmas = new ViewSeasonal()
		{
			SeasonalId = 2,
			SeasonalName = "Christmas",
			SeasonalStartDate = new DateTime(2021, 12, 04, 00, 00, 00, DateTimeKind.Utc),
			SeasonalEndDate = new DateTime(2021, 12, 26, 00, 00, 00, DateTimeKind.Utc)
		};
		private Seasonal christmas = new Seasonal()
		{
			SeasonalId = 2,
			SeasonalName = "Christmas",
			SeasonalStartDate = new DateTime(2021, 12, 04, 00, 00, 00, DateTimeKind.Utc),
			SeasonalEndDate = new DateTime(2021, 12, 26, 00, 00, 00, DateTimeKind.Utc)
		};
		private List<Seasonal> seasonals = new List<Seasonal>();
		private List<ViewSeasonal> viewSeasonals = new List<ViewSeasonal>();

		public SeasonalTest() : base(new DbContextOptionsBuilder<ShopDbContext>()
			.UseSqlite("Filename=Test.db")
			.Options, _mapper)
		{
			
		}

		[Fact]
		public void CorrectMappingToEF()
		{
			Seasonal seasonalTest = _mapper.ViewModelToModel(viewHalloween);
			Assert.Equal(1, seasonalTest.SeasonalId);
			Assert.Equal("Halloween", seasonalTest.SeasonalName);
			Assert.Equal(new DateTime(2021, 10, 25, 00, 00, 00, DateTimeKind.Utc), seasonalTest.SeasonalStartDate);
			Assert.Equal(new DateTime(2021, 11, 01, 00, 00, 00, DateTimeKind.Utc), seasonalTest.SeasonalEndDate);
		}

		[Fact]
		public void CorrectMappingToView()
		{
			ViewSeasonal viewSeasonalTest = _mapper.ModelToViewModel(halloween);
			Assert.Equal(1, viewSeasonalTest.SeasonalId);
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
