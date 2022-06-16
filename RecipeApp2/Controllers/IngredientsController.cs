using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApp2.Data;
using RecipeApp2.Entities;

namespace RecipeApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly RecipeContext _context;

        public IngredientsController(RecipeContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("SearchByName")]
        public async Task<IActionResult> SearchIngredientByName(string name, string name2) {

            var ingredients = await _context.Ingredients
                .Where(ingredient => ingredient.Name.Contains(name) &&
                                     ingredient.Name.Contains(name2)).Include("Category")
                .ToListAsync();

            if (ingredients == null || ingredients.Count == 0)
            {
                return NotFound("No ingredient by this name");
            }

            return Ok(ingredients);
        }

        [HttpPost]
        [Route("CreateRecipe")]
        public async Task<IActionResult> CreateRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                await _context.Recipes.AddAsync(recipe);
                await _context.SaveChangesAsync();

                return Ok();
            }
            else return BadRequest();
        }
    }
}
