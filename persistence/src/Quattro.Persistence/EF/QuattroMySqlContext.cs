using Microsoft.EntityFrameworkCore;

namespace Quattro.Persistence.EF
{
    public class QuattroMySqlContext : DbContext
    {
        public virtual DbSet<Entities.User> Users { get; set; }

        public QuattroMySqlContext(DbContextOptions<QuattroMySqlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Entities.User>().HasKey(u => u.Id);
        }
    }
}
