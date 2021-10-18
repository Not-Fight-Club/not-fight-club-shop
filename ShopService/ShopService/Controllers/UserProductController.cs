using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using BusinessLayer.Interface;
using BusinessLayer;
using DataLayerDbContext.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopService.Controllers
{
  [Route("api/[controller]")]
  public class UserProductController : Controller
  {

    private readonly IRepo<ViewUserProduct, int> _repo;
    private readonly IRepo<ViewUser, int> _userRepo;

    private readonly ILogger<ProductController> _logger;


    public UserProductController(IRepo<ViewUserProduct, int> repo, ILogger<ProductController> logger, IRepo<ViewUser, int> userrepo)
    {
      _repo = repo;
      _logger = logger;
      _userRepo = userrepo;
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

    [HttpPost("{id}")]
    public async Task<ActionResult<ViewUserProduct>> Post([FromBody] ViewProduct product, Guid id)
    {
      _logger.LogInformation("I'm here");
      _logger.LogInformation($"{id}");
      ViewUser user = await _userRepo.ReadUser(id);


      _logger.LogInformation($"{user.UserName}");
      //if (!ModelState.IsValid) return BadRequest("Invalid data.");

      //using (var client = new HttpClient())
      //{
      //  _logger.LogInformation("I'm inside using");
      //  client.BaseAddress = new Uri("http://localhost:5000");
      //  client.DefaultRequestHeaders.Accept.Clear();
      //  client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      //  // HTTP GET
      //  try
      //  {
      //    _logger.LogInformation("I'm inside try");
      //    HttpResponseMessage response = await client.GetAsync($"/users/{id}");
      //    _logger.LogInformation("I'm waiting");
      //    _logger.LogInformation($"{response}");
      //    if (response.IsSuccessStatusCode)
      //    {
      //      var res = await response.Content.ReadAsStringAsync();
      //      _logger.LogInformation($"{res}");

      //      var user = JsonConvert.DeserializeObject<ViewUser>(res);
      //      _logger.LogInformation($"{user}");
      //    }
      //    // Throw if not a success code.

      //    // ...
      //  }
      //  catch (HttpRequestException e)
      //  {
      //    // Handle exception.
      //}

      //should be able to get bucks from user table
      // ViewUser ur = await http.get().Read(userId); call userservice
      // bucks = ur.buck
      // var bucks = 0;
      // ViewProduct pr = await _productRepo.Read(productId);

      var discountedPrice = Discount.DiscountedCost(product.ProductPrice, product.ProductDiscount);
      // ViewUserProduct pp = new ViewUserProduct();

      // return Ok(pp);
      if (discountedPrice > user.Bucks)
      {
        _logger.LogInformation($"Not enough bucks to purchase");
        return NotFound($"Not enough money");
      }
      else
      {
        ViewUserProduct up = new ViewUserProduct(0, user.UserId, product.ProductId);

        var newUserProduct = await _repo.Add(up);
        _logger.LogInformation($"{user.UserName} purchased {product.ProductName}");

        return Ok(newUserProduct);
      //}




    }


    [HttpGet("[action]/{id}")]
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
