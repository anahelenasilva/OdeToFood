using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class Context : DbContext
    {
        public DbSet<Restaurant> Restaurant { get; set; }
    }
}