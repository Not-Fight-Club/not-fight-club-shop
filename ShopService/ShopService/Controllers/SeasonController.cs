using BusinessLayer.Interface;
using DataLayerDbContext.Models;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopService.Controllers
{
  [Route("api/[controller]")]
  public class SeasonController : Controller
  {
    private readonly IRepo<ViewSeasonal, DateTime> _repo;

    public SeasonController(IRepo<ViewSeasonal, DateTime> repo)
    {
      _repo = repo;
    }

    // GET: api/values
    [HttpGet]
    public Task<List<ViewSeasonal>> Get()
    {
      return _repo.Read();
    }

    [HttpGet("now")]
    public async Task<ActionResult<ViewSeasonal>> GetCurrentSeason()
    {
      DateTime date = DateTime.Now;
      ViewSeasonal season = await _repo.Read(date);
      return Ok(season);
    }

    // GET api/date/2021-10-06
    [HttpGet("{date}")]
		public async Task<ActionResult<ViewSeasonal>> GetSeasonByDate(DateTime date)
		{
			ViewSeasonal season = await _repo.Read(date);
			return Ok(season);
		}

    // POST api/values
    [HttpPost]
    public async Task<ActionResult<ViewSeasonal>> Post([FromBody] ViewSeasonal season)
    {
      if (!ModelState.IsValid) return BadRequest("Invalid data.");

      var newSeason = await _repo.Add(season);
      return Ok(newSeason);
    }

    // PUT api/values
    [HttpPut]
    public async Task<ActionResult<ViewSeasonal>> Put([FromBody] ViewSeasonal season)
    {
      if (!ModelState.IsValid) return BadRequest("Invalid data.");

      var newSeason = await _repo.Update(season);
      return Ok(newSeason);
    }
  }
}
