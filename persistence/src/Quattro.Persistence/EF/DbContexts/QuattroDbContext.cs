using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quattro.Persistence.EF
{
    public class QuattroDbContext : DbContext
    {
        public QuattroDbContext(DbContextOptions<QuattroDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
