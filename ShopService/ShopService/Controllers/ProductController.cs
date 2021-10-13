using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using Microsoft.Extensions.Logging;
using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopService.Controllers
{
    [Route("api/[controller]")]
  public class ProductController : Controller
  {

    private readonly IRepo<ViewProduct, int> _repo;

    private readonly ILogger<ProductController> _logger;

    public ProductController(IRepo<ViewProduct, int> repo, ILogger<ProductController> logger)
    {
      _repo = repo;
      _logger = logger;
    }

    // GET: api/values
    [HttpGet]
    public Task<List<ViewProduct>> Get()
    {
      return _repo.Read();
    }

    // GET: api/values/season/1
    [HttpGet("season/{seasonId}")]
    public Task<List<ViewProduct>> Get(int seasonId)
    {
      return _repo.ReadFromSeason(seasonId);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
      ViewProduct product = await _repo.Read(id);

      _logger.LogInformation($"{product.ProductName} was selected.");
      return Ok(product);
    }

    // POST api/values
    [HttpPost]
    public async Task<ActionResult<ViewProduct>> Post([FromBody] ViewProduct product)
    {
      if (!ModelState.IsValid) return BadRequest("Invalid data.");

      var newProduct = await _repo.Add(product);

      _logger.LogInformation($"{newProduct.ProductName} was added to product list.");
      return Ok(newProduct);

    }

    // PUT api/values/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // // DELETE api/values/5
    // [HttpDelete("{id}")]
    // public void Delete(int id)
    // {
    // }
  }
}
