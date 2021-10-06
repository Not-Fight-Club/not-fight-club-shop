using BusinessLayer.Interface;
using BusinessLayer.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using NotFightClub_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {
      

        private readonly ILogger<ShopController> _logger;
        private readonly IRepo<ViewUserProduct> _repo;
        private readonly IMapper<Product,ViewProduct> _mapper;

        public ShopController(ILogger<ShopController> logger, IRepo<ViewUserProduct> repo)
        {
            _logger = logger;
            _repo = repo;
            
        }

        [HttpGet("[controller]/[action]/{id}")]
        public async Task<ActionResult<List<ViewProduct>>> PreviousPurchases(Guid id)
        {
            //check if the model is good or not
            if (!ModelState.IsValid) return BadRequest();
            //make call to the repo to return all previous purchases
            List<ViewUserProduct> specificUserProducts = await _repo.ReadAll(id);
            
            //return action result with the list of previous purchases
            return Ok(specificUserProducts);
        }
    }
}
