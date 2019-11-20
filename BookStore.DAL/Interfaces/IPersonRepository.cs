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
        Task<Person> GetPersonByLoginAndPassword(string login, string password);
        Task<Person> GetPersonByRefreshToken(string refreshToken);
        Task<bool> CheckReduplicationUserName(string UserName);
        Task<bool> CheckReduplicationEmail(string Email);
        Task<Person> GetPersonByEmail(string email);
        Task<bool> ResetPassword(string password, string resetPasswordGuid);
    }
}
