using BookStore.Common.ViewModels;
using BookStore.DAL.Models;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IHomeService
    {
        Task CreatePersonAsync(User person);
        Task CreateAndGetAllCommentsAsync(string UserName, string Comment);
        Task<string> CreateBookCategoryAvtorTablesAsync(CreateBookViewModel createBookViewModel);
        Task<User> GetPersonByLoginAndPasswordAsync(string login, string password);
    }
}
