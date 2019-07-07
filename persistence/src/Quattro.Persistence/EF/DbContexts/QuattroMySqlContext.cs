using Microsoft.EntityFrameworkCore;

namespace Quattro.Persistence.EF
{
    public class QuattroMySqlContext : DbContext
    {
        public QuattroMySqlContext(DbContextOptions<QuattroMySqlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
