using BookStore.DAL.Models;
using BookStore.DAL.Repositories.EntityFramework;
using BookStore.Services.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BookStore.Services.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAllPerson();
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(int id);
        Person GetPersonById(int id);

        Person GetPersonByLoginAndPassword(string login, string password);
        Person GetPersonByRefreshToken(string refreshToken);
    }
}
