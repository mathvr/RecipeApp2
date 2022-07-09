using RecipeApp2.Entities.Categories;
using RecipeApp2.Entities.Recipes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace RecipeApp2.Entities.Ingredients
{
    public class Ingredient
    {
        public Ingredient()
        {
            Recipes = new List<Recipe>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        [AllowNull]
        public virtual IEnumerable<Recipe> Recipes { get; set; }
        [AllowNull]
        public Category Category { get; set; }
    }
}
