using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurant { get; set; }
    }
}