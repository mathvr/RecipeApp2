using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RecipeApp2.Entities
{
    public class Recipe
    {
        public Recipe()
        {
            this.Ingredients = new List<Ingredient>();
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
