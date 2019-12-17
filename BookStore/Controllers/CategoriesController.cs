using System.Threading.Tasks;
using BookStore.Common.ViewModels.CategoriesController.Get;
using BookStore.Common.ViewModels.CategoriesController.Post;
using BookStore.Common.ViewModels.CategoriesController.Put;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AddTestCors")]
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<AllCategoryViewModel> GetAllCategories()
        {
            AllCategoryViewModel result = await _categoryService.GetAllCategoryAsync();

            return result;
        }

        [HttpGet("{id}")]
        public async Task<CategoryByIdViewModel> GetCategoryById(int id)
        {
            CategoryByIdViewModel result = await _categoryService.GetCategoryByIdAsync(id);

            return result;
        }

        [HttpPost]
        public async Task CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {
            await _categoryService.CreateCategoryAsync(createCategoryViewModel);
        }

        [HttpPut]
        public async Task UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryViewModel);
        }

        [HttpDelete("{id}")]
        public async Task DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
        }

        [HttpGet("category/{category}")]
        public async Task<CategoryBooksViewModel> GetCategoriesBooks(int category)
        {
            CategoryBooksViewModel bookItem = await _categoryService.GetCategoryBooksAsync(category);

            return bookItem;
        }

        [HttpGet("avtorandcategory/{avtor}/{category}")]
        public async Task<AuthorAndCategoryViewModel> GetAvtorandCategoryBooks(int category, string avtor)
        {
            AuthorAndCategoryViewModel bookItem = await _categoryService.GetAutorAndCategoryBookAsync(avtor, category);
             
            return bookItem;
        }
    }
}