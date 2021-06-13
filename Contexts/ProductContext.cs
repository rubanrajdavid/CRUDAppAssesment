using Microsoft.EntityFrameworkCore;
using CRUDAppAssesment.Models;

namespace CRUDAppAssesment.Contexts
{
    public class ProductContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        //Create a Table named Products with Product Model
    }
}
