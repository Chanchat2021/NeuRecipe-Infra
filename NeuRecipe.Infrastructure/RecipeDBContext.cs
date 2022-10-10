using Microsoft.EntityFrameworkCore;
using NeuRecipe.Domain.Entity;
using System.Reflection;

namespace NeuRecipe.Infrastructure
{
    public class RecipeDBContext : DbContext
    {
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<User> User { get; set; }

        public RecipeDBContext(DbContextOptions<RecipeDBContext> contextOptions) : base(contextOptions)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
