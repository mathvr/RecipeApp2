using RecipeApp2.Entities.Categories;

namespace RecipeApp2.Services.CateogoryServices;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategories();
}