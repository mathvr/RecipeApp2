using RecipeApp2.Entities.Ingredients;

namespace RecipeApp2.Entities.Recipes
{
    public class CreateRecipeDTO
    {
        public string Name { get; set; }
        public string Healthy { get; set; }
        public string Spicy { get; set; }
        public List<IngredientFromClientDTO> Ingredients { get; set; }

    }
}
