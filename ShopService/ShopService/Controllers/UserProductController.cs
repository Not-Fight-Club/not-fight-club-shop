using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using BusinessLayer.Interface;
using DataLayerDbContext.Models;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopService.Controllers
{
  [Route("api/[controller]")]
  public class UserProductController : Controller
  {

    private readonly IRepo<ViewUserProduct, int> _repo;

    public UserProductController(IRepo<ViewUserProduct, int> repo)
    {
      _repo = repo;
    }
    // GET: api/values
    // [HttpGet]
    // public IEnumerable<string> Get()
    // {
    //     return new string[] { "value1", "value2" };
    // }

    // GET api/values/5
    // [HttpGet("purchaseProduct/{userId}/{productId}")]
    // public async Task<ActionResult<UserProduct>> Get(int userId, int productId)
    // {

    // }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserProduct>> GetUserProductById(int id)
    {
      ViewUserProduct userProduct = await _repo.Read(id);
      return Ok(userProduct);
    }

    [HttpPost]
    public async Task<ActionResult<ViewUserProduct>> Post([FromBody] ViewUserProduct userProduct)
    {
      if (!ModelState.IsValid) return BadRequest("Invalid data.");

      var newUserProduct = await _repo.Add(userProduct);
      return Ok(newUserProduct);

    }

    // // PUT api/values/5
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
