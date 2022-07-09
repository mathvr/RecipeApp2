using Microsoft.EntityFrameworkCore;
using RecipeApp2.Data;
using RecipeApp2.Entities.Recipes;

namespace RecipeApp2.Services.RecipeServices
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeContext _context;

        public RecipeService(RecipeContext context)
        {
            _context = context;
        }
        public async Task AddRecipe(CreateRecipeDTO recipeDTO)
        {
            var recipe = new Recipe()
            {
                Healthy = recipeDTO.Healthy,
                Name = recipeDTO.Name,
                Spicy = recipeDTO.Spicy,
            };
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();

            await AddIngredientsToRecipe(recipeDTO, recipe);
        }
        public async Task AddIngredientsToRecipe(CreateRecipeDTO recipeDto, Recipe createdrecipe)
        {
            var ingredients = _context.Ingredients.Where(ingredient =>
                recipeDto.Ingredients.Select(ingredientDTO => 
                    ingredientDTO.Id).Contains(ingredient.Id)).ToList();

            createdrecipe.Ingredients = ingredients;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RecipeGetDTO>> GetRecipesbyName(string recipeName)
        {
            List<RecipeGetDTO> recipeListForClient = new List<RecipeGetDTO>();

            await _context.Recipes.Where(recipe => recipe.Name.Contains(recipeName))
                .ForEachAsync(recipe => recipeListForClient.Add(MapRecipe(recipe)));

            if (recipeListForClient.Count == 0)
            {
                await _context.Recipes.Take(10).ForEachAsync(recipe => recipeListForClient.Add(MapRecipe(recipe)));

                return recipeListForClient;
            }
            return recipeListForClient;
        }

        public async Task DeleteRecipe(int recipeId)
        {
            var recipeToDelete = await _context.Recipes.FirstOrDefaultAsync(recipe => recipe.Id == recipeId);

            if (recipeToDelete is null)
            {
                throw new Exception("No recipe for this Id");
            }

            _context.Recipes.Remove(recipeToDelete);
            await _context.SaveChangesAsync();
        }

        public RecipeGetDTO MapRecipe(Recipe recipe)
        {
            return new RecipeGetDTO()
            {
                Healthy = recipe.Healthy,
                Name = recipe.Name,
                Spicy = recipe.Spicy, 
                Id = recipe.Id
            };
        }
    }
}
