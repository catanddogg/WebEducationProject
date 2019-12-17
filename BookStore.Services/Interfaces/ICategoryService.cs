using BookStore.Common.ViewModels.CategoriesController.Get;
using BookStore.Common.ViewModels.CategoriesController.Post;
using BookStore.Common.ViewModels.CategoriesController.Put;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<AllCategoryViewModel> GetAllCategoryAsync();
        Task<CategoryByIdViewModel> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(CreateCategoryViewModel createCategoryViewModel);
        Task UpdateCategoryAsync(UpdateCategoryViewModel updateCategoryViewModel);
        Task DeleteCategoryAsync(int id);
        Task<CategoryBooksViewModel> GetCategoryBooksAsync(int category);
        Task<AuthorAndCategoryViewModel> GetAutorAndCategoryBookAsync(string avtor, int category);
    }
}
