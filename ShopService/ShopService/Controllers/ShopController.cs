using BusinessLayer.Interface;
using BusinessLayer.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelsLayer.ViewModels;
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
        private readonly IRepo<ShopRepo> _repo;

        public ShopController(ILogger<ShopController> logger, IRepo<ShopRepo> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet("[controller]/[action]/{id}")]
        public async Task<ActionResult<List<ViewProduct>>> PreviousPurchases(Guid id)
        {
            //check if the model is good or not
            //make call to the repo to return all previous purchases
            //return action result with the list of previous purchases
            return _repo.ReadAll(id);
        }
    }
}
