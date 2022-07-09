using Microsoft.AspNetCore.Mvc;
using RecipeApp2.Entities.Categories;
using RecipeApp2.Services.CateogoryServices;

namespace RecipeApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _service.GetAllCategories();
        }
    }
}
