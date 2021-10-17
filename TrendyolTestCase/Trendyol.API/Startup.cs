using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Trendyol.Data.TrendyolContext;

namespace Trendyol.API
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
            //Read appsetting.json
            //services.AddOptions();
            //services.Configure<X>(Configuration.GetSection("x"));

            //Dependency Injection
            DependencyInjection(services);
            //Swagger
            AddSwagger(services);
            //PostgreSql Connection
            PostgresSqlConnection(services);

            services.AddLogging();
            services.AddControllers();
        }

        private void PostgresSqlConnection(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<TrendyolPostgreSqlContext>(opt =>
                               opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Core API", Description = "Trendyol API" });
            });
        }

        private void DependencyInjection(IServiceCollection services)
        {
            var dependency = new DependencyRegister(services);
            dependency.Register();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Swagger API UI
                app.UseSwagger();
                app.UseSwaggerUI(x =>
                {
                    x.SwaggerEndpoint("/swagger/v1/swagger.json", "Trendyol API");
                });
            }
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
