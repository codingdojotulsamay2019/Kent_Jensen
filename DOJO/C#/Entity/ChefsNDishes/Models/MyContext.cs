using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Dish> Dishes {get;set;}
        public DbSet<Dish> CreatedDishes {get;set;}
        public DbSet<Chef> Chefs {get;set;}
        public DbSet<Chef> AllChefs {get;set;}
        public MyContext(DbContextOptions options) : base(options) { }
        
    }
}