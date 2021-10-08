﻿using BusinessLayer.Interface;
using DataLayerDbContext.Models;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repo
{
  public class SeasonRepo : IRepo<ViewSeasonal, int>
  {
    private readonly ShopDbContext _dbContext = new ShopDbContext();

    private readonly IMapper<Seasonal, ViewSeasonal> _mapper;

    public SeasonRepo(IMapper<Seasonal, ViewSeasonal> mapper)
    {

      _mapper = mapper;
    }

    /// <summary>
    /// Adds a new season to the database
    /// </summary>
    /// <param name="viewSeasonal"></param>
    /// <returns></returns>
    public async Task<ViewSeasonal> Add(ViewSeasonal viewSeasonal)
    {
      Seasonal seasonal = _mapper.ViewModelToModel(viewSeasonal);

      _dbContext.Database.ExecuteSqlInterpolated($"Insert into Seasonal(SeasonalName, SeasonalStartDate, SeasonalEndDate) values({seasonal.SeasonalName},{seasonal.SeasonalStartDate},{seasonal.SeasonalEndDate})");
      _dbContext.SaveChanges();

      Seasonal newSeason = await _dbContext.Seasonals.FromSqlInterpolated($"select * from Seasonal where SeasonalName = {seasonal.SeasonalName}").FirstOrDefaultAsync();
      return _mapper.ModelToViewModel(newSeason);
    }

    /// <summary>
    /// Returns a season from the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ViewSeasonal> Read(int id)
    {
      Seasonal season = await _dbContext.Seasonals.FromSqlInterpolated($"select * from Seasonal where SeasonalId = {id}").FirstOrDefaultAsync();

      return _mapper.ModelToViewModel(season);
    }

    /// <summary>
    /// Returns all the seasons from the database
    /// </summary>
    /// <returns></returns>
    public async Task<List<ViewSeasonal>> Read()
    {
      List<Seasonal> seasons = await _dbContext.Seasonals.ToListAsync();
      return _mapper.ModelToViewModel(seasons);
    }

    /// <summary>
    /// Returns a season from the database based on the date
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public async Task<ViewSeasonal> Read(DateTime date)
    {
      Seasonal season = await _dbContext.Seasonals.FromSqlInterpolated($"select * from Seasonal where SeasonalStartDate > {date} AND SeasonalEndDate < {date}").FirstOrDefaultAsync();
      return _mapper.ModelToViewModel(season);
    }

    /// <summary>
    /// Updates the season. The season's ID is the value to check
    /// </summary>
    /// <param name="viewSeasonal"></param>
    /// <returns></returns>
    public async Task<ViewSeasonal> Update(ViewSeasonal viewSeasonal)
    {
      Seasonal seasonal = _mapper.ViewModelToModel(viewSeasonal);
      _dbContext.Database.ExecuteSqlInterpolated($"Update Seasonal Set SeasonalName={seasonal.SeasonalName}, SeasonalStartDate={seasonal.SeasonalStartDate}, SeasonalEndDate={seasonal.SeasonalEndDate} Where SeasonalId={seasonal.SeasonalId}");

      Seasonal newSeason = await _dbContext.Seasonals.FromSqlInterpolated($"select * from Seasonal where SeasonalName = {seasonal.SeasonalName}").FirstOrDefaultAsync();
      return _mapper.ModelToViewModel(newSeason);
    }

    public Task<List<ViewSeasonal>> ReadAll(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<ViewSeasonal> ReadUser(Guid id)
    {
      throw new NotImplementedException();
    }
  }//EoC
}//EoN
