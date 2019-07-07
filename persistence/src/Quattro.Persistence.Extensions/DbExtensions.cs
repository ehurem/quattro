using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Quattro.Persistence.EF;

namespace Quattro.Persistence.Extensions
{
    /// <summary>
    /// Extension methods to add EntityFramework database and unit of work support for Quattro applications.
    /// </summary>
    public static class DbExtensions
    {
        public static IServiceCollection UseDbContextAndUnitOfWork<TContext, TUnitOfWork>(this IServiceCollection services, Action<DatabaseOptions> databaseOptionsAction)
            where TContext : DbContext
            where TUnitOfWork : UnitOfWork, IQuattroUnitOfWork
        {
            var dbOptions = new DatabaseOptions();

            databaseOptionsAction?.Invoke(dbOptions);

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

            services.AddScoped<IQuattroUnitOfWork, TUnitOfWork>();
            return services;
        }
    }
}
