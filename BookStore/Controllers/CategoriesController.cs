using System.Threading.Tasks;
using BookStore.Common.ViewModels.CategoriesController.Get;
using BookStore.Common.ViewModels.CategoriesController.Post;
using BookStore.Common.ViewModels.CategoriesController.Put;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AddTestCors")]
    //[Authorize]

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
            AllCategoryViewModel result = await _categoryService.GetAllCategory();

            return result;
        }

        [HttpGet("{id}")]
        public CategoryByIdViewModel GetCategoryById(int id)
        {
            return _categoryService.GetCategoryById(id);
        }

        [HttpPost]
        public void CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {
            _categoryService.CreateCategory(createCategoryViewModel);
        }

        [HttpPut]
        public void UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel)
        {
            _categoryService.UpdateCategory(updateCategoryViewModel);
        }

        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
        }

        [HttpGet("category/{category}")]
        public async Task<CategoryBooksViewModel> GetCategoriesBooks(int category)
        {
            CategoryBooksViewModel bookItem = await _categoryService.GetCategoryBooks(category);

            return bookItem;
        }

        [HttpGet("avtorandcategory/{avtor}/{category}")]
        public async Task<AuthorAndCategoryViewModel> GetAvtorandCategoryBooks(int category, string avtor)
        {
            AuthorAndCategoryViewModel bookItem = await _categoryService.GetAutorAndCategoryBook(avtor, category);
             
            return bookItem;
        }
    }
}