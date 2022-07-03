using Microsoft.EntityFrameworkCore;
using RecipeApp2.Entities;
using RecipeApp2.Entities.Categories;
using RecipeApp2.Entities.Ingredients;
using RecipeApp2.Entities.Recipes;

namespace RecipeApp2.Data
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        {

        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
