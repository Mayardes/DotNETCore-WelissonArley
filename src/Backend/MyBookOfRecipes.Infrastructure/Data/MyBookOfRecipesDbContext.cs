using Microsoft.EntityFrameworkCore;
using MyBookOfRecipes.Domain.Entities;
using System.Reflection;

namespace MyBookOfRecipes.Infrastructure.Data
{
    public class MyBookOfRecipesDbContext(DbContextOptions<MyBookOfRecipesDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
