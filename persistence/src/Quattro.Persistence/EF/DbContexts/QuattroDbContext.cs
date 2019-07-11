using Microsoft.EntityFrameworkCore;
using Quattro.Domain.Entities;

namespace Quattro.Persistence.EF
{
    public class QuattroDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Scope> Scopes { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<TimeClock> TimeClocks { get; set; }

        public DbSet<User> Users { get; set; }

        public QuattroDbContext(DbContextOptions<QuattroDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
