using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CalcOnline.Services;
using CalcOnline.Data.Interface;
using CalcOnline.Data.Extentions;

namespace CalcOnline
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICalculator, Calculator>();           
        }
      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCalculator();
        }
    }
}
