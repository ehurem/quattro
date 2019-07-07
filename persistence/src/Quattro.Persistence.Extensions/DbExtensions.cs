using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Quattro.Persistence.EF;
using Quattro.Persistence;

namespace Quattro.Persistence.Extensions
{
    public static class DbExtensions
    {

        public static IServiceCollection ConfigureDatabase<TContext, TUnitOfWork>(this IServiceCollection services, Action<DatabaseOptions> func)
            where TContext : DbContext
            where TUnitOfWork : UnitOfWork
        {
            var dbOptions = new DatabaseOptions();

            func(dbOptions);

            if (string.IsNullOrWhiteSpace(dbOptions.ConnectionString))
                throw new ArgumentNullException(nameof(dbOptions.ConnectionString));


            services.AddDbContext<TContext>(options =>
            {
                options
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();

                switch (dbOptions.Database)
                {
                    case Database.MySql:
                        options.UseMySQL(dbOptions.ConnectionString);
                        break;
                    case Database.SqlServer:
                        options.UseSqlServer(dbOptions.ConnectionString);
                        break;
                    default:
                        options.UseSqlServer(dbOptions.ConnectionString);
                        break;
                }
            });

            services.AddScoped<TUnitOfWork>();

            return services;
        }
    }
}
