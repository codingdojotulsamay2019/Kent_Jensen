using Microsoft.EntityFrameworkCore;

namespace Crudlicious.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Dish> Dishes {get;set;}
        public DbSet<Dish> AllDishes {get;set;}
        public MyContext(DbContextOptions options) : base(options) { }
        
    }
}