using BusinessLayer.Interface;
using BusinessLayer.Mapper;
using BusinessLayer.Repo;
using DataLayerDbContext.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopService
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ShopDbContext>();
      services.AddSingleton<IRepo<ViewProduct, int>, ProductRepository>();
      services.AddSingleton<IMapper<Product, ViewProduct>, ProductMapper>();
      services.AddSingleton<IRepo<ViewUserProduct, int>, UserProductRepository>();
      services.AddSingleton<IMapper<UserProduct, ViewUserProduct>, UserProductMapper>();
        services.AddSingleton<IRepo<ViewSeasonal, int>, SeasonRepo>();
        services.AddSingleton<IRepo<ViewSeasonal, DateTime>, SeasonDateRepo>();
        services.AddSingleton<IMapper<Seasonal, ViewSeasonal>, SeasonalMapper>();
        services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopService", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopService v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
