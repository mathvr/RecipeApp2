using RecipeApp2.Entities.Recipes;

namespace RecipeApp2.Services.RecipeServices;

public interface IRecipeService
{
    Task AddRecipe(CreateRecipeDTO recipeDTO);
    Task AddIngredientsToRecipe(CreateRecipeDTO recipeDto, Recipe createdrecipe);
    Task<IEnumerable<RecipeGetDTO>> GetRecipesbyName(string recipeName);
    Task DeleteRecipe(int recipeId);
}