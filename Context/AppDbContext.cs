using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set;}
        public DbSet<Category> Categories { get; set; }   
    }
}
