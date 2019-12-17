using BookStore.DAL.Models;
using BookStore.DAL.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<Person> GetPersonByLoginAndPasswordAsync(string login, string password);
        Task<Person> GetPersonByRefreshTokenAsync(string refreshToken);
        Task<bool> CheckReduplicationUserNameAsync(string UserName);
        Task<bool> CheckReduplicationEmailAsync(string Email);
        Task<Person> GetPersonByEmailAsync(string email);
        Task<bool> ResetPasswordAsync(string password, string resetPasswordGuid);
    }
}
