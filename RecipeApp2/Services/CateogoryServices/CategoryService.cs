using Microsoft.EntityFrameworkCore;
using RecipeApp2.Data;
using RecipeApp2.Entities.Categories;

namespace RecipeApp2.Services.CateogoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly RecipeContext _context;
        public CategoryService(RecipeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            if (_context.Categories.Any())
            {
                return await _context.Categories.ToListAsync();
            }

            throw new Exception("The categories are not initialized!");
        }

    }
}
