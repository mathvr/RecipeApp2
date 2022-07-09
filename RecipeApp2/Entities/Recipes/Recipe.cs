
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using RecipeApp2.Entities.Ingredients;

namespace RecipeApp2.Entities.Recipes
{
    public class Recipe
    {
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Healthy { get; set; }
        public string Spicy { get; set; }
        [AllowNull]
        public IEnumerable<Ingredient> Ingredients { get; set; }

    }
}
