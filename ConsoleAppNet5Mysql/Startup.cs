using ConsoleApp4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SqlContext>();
            //services.AddDbContextPool<SqlContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
            //    ServerVersion.Parse("8.0.20-mysql")));
        }
    }
}
