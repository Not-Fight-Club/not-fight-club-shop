using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;




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

    [HttpGet("api/[controller]/[action]")]
    public async Task<ActionResult<List<ViewProduct>>> PreviousPurchases(Guid id)
    {
        //check if the model is good or not
        if (!ModelState.IsValid) return BadRequest();
        //make call to the repo to return all previous purchases
        List<ViewUserProduct> specificUserProducts = await _repo.ReadAll(id);

        //return action result with the list of previous purchases
        return Ok(specificUserProducts);
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
