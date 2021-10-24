using Final.DatabaseLevel;
using Final.DomainLevel;
using Final.Models;
using Final.ServiceLevel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Host=localhost;Port=5432;Database=MyDatabase;Username=postgres;Password=admin";
            services.AddDbContext<MyDBContext>(options => options.UseNpgsql(connectionString));

            services.AddTransient<ICarService, CarService>();
            services.AddScoped<ICarDomain, CarDomain>();
            services.AddControllers();
        }

        public void Configure(
            IApplicationBuilder app
            )
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
