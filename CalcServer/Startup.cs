
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CalcOnline.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using CalcOnline.Data.Interface;

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

            //app.Run(context => {
            //    context.
            //});
        }
    }
}
