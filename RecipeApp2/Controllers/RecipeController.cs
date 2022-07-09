using Microsoft.AspNetCore.Mvc;
using RecipeApp2.Entities.Recipes;
using RecipeApp2.Services.RecipeServices;

namespace RecipeApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController: ControllerBase

    {
        private readonly IRecipeService _service;
        public RecipeController(IRecipeService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateRecipe")]
        public async Task<IActionResult> CreateRecipe(CreateRecipeDTO recipeDTO)
        {
            if (ModelState.IsValid)
            {
                await _service.AddRecipe(recipeDTO);

                return Ok("Recipe created successfully");
            }
            else return BadRequest();
        }

        [HttpGet]
        [Route("GetRecipes")]
        public async Task<IEnumerable<RecipeGetDTO>> GetRecipes(string? recipeName)
        {
            return await _service.GetRecipesbyName(recipeName);
        }

        [HttpDelete]
        [Route("DeleteRecipe/{recipeId}")]
        public async Task<IActionResult> DeleteRecipe(int recipeId)
        {
            await _service.DeleteRecipe(recipeId);
            return Ok("Recipe deleted successfully");
        }
    }
}
