using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApp2.Data;
using RecipeApp2.Entities.EntitiesDTO;
using RecipeApp2.Entities.Ingredients;
using RecipeApp2.Entities.Recipes;
using RecipeApp2.Services.IngredientServices;

namespace RecipeApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _service;

        public IngredientsController(IIngredientService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("SearchByName")]
        public async Task<IEnumerable<IngredientToClientDTO>> SearchIngredientByName(string name, string name2)
        {
            var ingredients = _service.SearchIngredientByName(name, name2);

            if (ingredients is null) throw new Exception("Ingredients not found");

            return await ingredients;
        }

        [HttpPost]
        [Route("AddIngredient")]
        public async Task<IActionResult> AddIngredient(IngredientToAddDTO ingredient)
        {
            await _service.AddIngredient(ingredient.Name, ingredient.CategoryId);

            return Ok("Ingredient added successfully");
        }
        
    }
}
