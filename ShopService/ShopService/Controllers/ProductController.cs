using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayerDbContext.Models;
using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopService.Controllers
{
  [Route("api/[controller]")]
  public class ProductController : Controller
  {

    private readonly IRepo<ViewProduct, int> _repo;

    public ProductController(IRepo<ViewProduct, int> repo)
    {
      _repo = repo;
    }

    // GET: api/values
    [HttpGet]
    public IEnumerable<Product> Get()
    {
      using (ShopDbContext allProducts = new ShopDbContext())
      {
        return allProducts.Products.ToList();
      }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
      ViewProduct product = await _repo.Read(id);
      return Ok(product);
    }

    // POST api/values
    [HttpPost]
    public async Task<ActionResult<ViewProduct>> Post([FromBody] ViewProduct product)
    {
      if (!ModelState.IsValid) return BadRequest("Invalid data.");

      var newProduct = await _repo.Add(product);
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
