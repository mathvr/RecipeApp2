using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace RecipeApp2.Entities
{
    public class Ingredient
    {
        public Ingredient()
        {
            this.Recipes = new List<Recipe>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        [AllowNull]
        public IEnumerable<Recipe> Recipes { get; set; }
        [AllowNull]
        public Category Category { get; set; }
    }
}
