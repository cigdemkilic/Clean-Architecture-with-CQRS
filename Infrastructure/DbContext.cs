using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public DbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Persons> Persons { get; set; }
    }
}

