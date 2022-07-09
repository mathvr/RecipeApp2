using Microsoft.EntityFrameworkCore;
using RecipeApp2.Data;
using RecipeApp2.Entities;
using RecipeApp2.Entities.EntitiesDTO;
using RecipeApp2.Entities.Ingredients;

namespace RecipeApp2.Services.IngredientServices
{
    public class IngredientService : IIngredientService
    {
        private readonly RecipeContext _context;
        public IngredientService(RecipeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IngredientToClientDTO>> SearchIngredientByName(string name, string name2)
        {
            var ingredients = await _context.Ingredients
                .Where(ingredient => ingredient.Name.Contains(name) &&
                                     ingredient.Name.Contains(name2))
                .ToListAsync();

            List<IngredientToClientDTO> ingredientsDTO = new List<IngredientToClientDTO>();

            ingredients.ForEach(ingredient => 
                ingredientsDTO.Add(new IngredientToClientDTO()
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name,
                }));

            return  ingredientsDTO;
        }

        public async Task AddIngredient(string ingredientName, int categoryId)
        {
            _context.Ingredients.Add(new Ingredient()
                {
                    Category = await _context.Categories.FirstAsync(category => category.Id.Equals(categoryId)),
                    Id = (await _context.Ingredients.MaxAsync(ingredient => ingredient.Id)) + 1,
                    Name = ingredientName
                }
            );
            await _context.SaveChangesAsync();
        }
    }
}
