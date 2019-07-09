using BookStore.DAL.Models;
using BookStore.DAL.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BookStore.DAL.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Person GetPersonByLoginAndPassword(string login, string password);
        Person GetPersonByRefreshToken(string refreshToken);
    }
}
