using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class MyContext : DbContext
    {
        public DbSet<User> Users {get;set;}
        public DbSet<Event> Events {get;set;}
        public DbSet<Attending> Attendings {get;set;}
        public MyContext(DbContextOptions options) : base(options) { }
    }
}