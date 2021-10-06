using BusinessLayer.Interface;
using BusinessLayer.Mapper;
using BusinessLayer.Repo;
using DataLayerDbContext.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ModelsLayer.Models;
using ModelsLayer.ViewModels;


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
            //added cors policy with orgin local host addresses
            services.AddCors((options) =>
            {
                options.AddPolicy(name: "shop", builder =>
                 {
                     builder.WithOrigins(
                   "http:localhost4200:",
                   "https:localhost:5001",
                   "https:localhost:5000",
                   "http:localhost:5000"

                   )
                .AllowAnyHeader()
                .AllowAnyMethod();


                  });
       

            });



      services.AddControllers();
      services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopService", Version = "v1" });
      });


            //added dbcontext dependency
            services.AddDbContext<ShopDbContext>(options =>
            {
                if (!options.IsConfigured)
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ShopLocalDb"));
                }
            });//end dbcontext dependency
            


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddFile("Logs/app-{Date}.txt");

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopService v1"));
      }

      app.UseDeveloperExceptionPage();

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors("shop");

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
