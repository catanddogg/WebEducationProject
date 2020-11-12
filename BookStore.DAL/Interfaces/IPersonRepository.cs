using BookStore.DAL.Models;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface IPersonRepository : IBaseRepository<User>
    {
        Task<User> GetPersonByLoginAndPasswordAsync(string login, string password);
        Task<User> GetPersonByRefreshTokenAsync(string refreshToken);
        Task<bool> CheckReduplicationUserNameAsync(string UserName);
        Task<bool> CheckReduplicationEmailAsync(string Email);
        Task<User> GetPersonByEmailAsync(string email);
        Task<bool> ResetPasswordAsync(string password, string resetPasswordGuid);
    }
}
