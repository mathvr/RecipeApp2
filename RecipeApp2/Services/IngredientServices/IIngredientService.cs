using RecipeApp2.Entities;
using RecipeApp2.Entities.EntitiesDTO;

namespace RecipeApp2.Services.IngredientServices;

public interface IIngredientService
{
    Task<IEnumerable<IngredientToClientDTO>> SearchIngredientByName(string name, string name2);
    Task AddIngredient(string ingredientName, int categoryId);
}