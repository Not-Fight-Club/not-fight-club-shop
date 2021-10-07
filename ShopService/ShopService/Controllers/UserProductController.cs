﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using BusinessLayer.Interface;
using BusinessLayer;
using DataLayerDbContext.Models;
using Microsoft.Extensions.Logging;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopService.Controllers
{
  [Route("api/[controller]")]
  public class UserProductController : Controller
  {

    private readonly IRepo<ViewUserProduct, int> _repo;

    private readonly ILogger<ProductController> _logger;


    public UserProductController(IRepo<ViewUserProduct, int> repo, ILogger<ProductController> logger)
    {
      _repo = repo;
      _logger = logger;
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

    [HttpPost()]
    public async Task<ActionResult<ViewUserProduct>> Post([FromBody] ViewUser user, ViewProduct product)
    {
      if (!ModelState.IsValid) return BadRequest("Invalid data.");
      //should be able to get bucks from user table
      // ViewUser ur = await _pro.Read(userProduct.UserId);
      // bucks = ur.buck
      // var bucks = 0;
      // ViewProduct pr = await _pro.Read(userProduct.ProductId);

      var discountedPrice = Discount.DiscountedCost(product.ProductPrice, product.ProductDiscount);


      if (discountedPrice > user.Bucks)
      {
        _logger.LogInformation($"Not enough bucks to purchase");
        return NotFound($"Not enough money");
      }
      else
      {
        ViewUserProduct up = new ViewUserProduct(0, user.UserId, product.ProductId);


        var newUserProduct = await _repo.Add(up);
        _logger.LogInformation($"User with user id: {newUserProduct.UserId} purchased {product.ProductName}");

        return Ok(newUserProduct);
      }




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
