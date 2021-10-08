using Microsoft.EntityFrameworkCore;
using BusinessLayer.Interface;
using DataLayerDbContext.Models;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BusinessLayer.Repo
{
  public class UserRepository : IRepo<ViewUser, int>
  {

    private IHttpClientFactory _clientFactory;
    private ILogger<UserRepository> _logger;
    private IConfiguration _config;
    public UserRepository(IHttpClientFactory clientFactory, ILogger<UserRepository> logger, IConfiguration config)
    {
      _clientFactory = clientFactory;
      _logger = logger;
      _config = config;
    }
    public Task<ViewUser> Add(ViewUser obj)
    {
      throw new NotImplementedException();
    }

    public Task<ViewUser> Read(int obj)
    {
      throw new NotImplementedException();
    }

    public Task<List<ViewUser>> Read()
    {
      throw new NotImplementedException();
    }

    public async Task<ViewUser> ReadUser(Guid id)
    {
      // Access microservice for users
      string baseUrl = _config["userApiUrl"];
      //string endpointURI = $"{baseUrl}/Character/{characterId}";
      string endpointURI = $"{baseUrl}/api/User/{id}";
      var request = new HttpRequestMessage(HttpMethod.Get, endpointURI);
      var client = _clientFactory.CreateClient();
      _logger.LogInformation($"base address for client api: {client.BaseAddress}");
      var response = await client.SendAsync(request);
      if (response.IsSuccessStatusCode)
      {
        string responseJson = await response.Content.ReadAsStringAsync();
        _logger.LogInformation($"{responseJson}");
        return JsonConvert.DeserializeObject<ViewUser>(responseJson);
      }
      else
      {
        _logger.LogError($"Failed request to {endpointURI}: {response}");
        return null;
      }
    }

    public Task<List<ViewUser>> ReadAll(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<ViewUser> Update(ViewUser obj)
    {
      throw new NotImplementedException();
    }

  }
}