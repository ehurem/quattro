using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quattro.Persistence.EF;
using Quattro.Persistence.EF.DbContexts;

namespace Quattro.Persistence.Migrations
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var databaseType = Configuration["DatabaseType"];
            var connectionString = Configuration.GetConnectionString(databaseType);

            switch (databaseType.ToLower())
            {
                case "mysql":
                    services.AddDbContext<QuattroMySqlContext>((options) =>
                    {
                        options.EnableDetailedErrors().EnableSensitiveDataLogging();

                        options.UseMySQL(connectionString, (mySqlOptions) => mySqlOptions.MigrationsAssembly(typeof(Startup).Assembly.FullName));
                    });
                    break;
                case "sqlserver":
                    services.AddDbContext<QuattroDbContext>((options) =>
                    {
                        options.EnableDetailedErrors().EnableSensitiveDataLogging();

                        options.UseSqlServer(connectionString, (sqlServerOptions) => sqlServerOptions.MigrationsAssembly(typeof(Startup).Assembly.FullName));
                    });
                    break;
                case "sqlite":
                    services.AddDbContext<QuattroSQLiteContext>((options) =>
                    {
                        options.EnableDetailedErrors().EnableSensitiveDataLogging();

                        options.UseSqlite(connectionString, (sqliteOptions) => sqliteOptions.MigrationsAssembly(typeof(Startup).Assembly.FullName));
                    });
                    break;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
