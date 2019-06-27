using BookStore.DAL.Models;
using BookStore.DAL.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BookStore.DAL.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPerson();
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(int id);

        Person GetPersonByLoginAndPassword(string login, string password);
        Person GetPersonById(int id);
        Person GetPersonByRefreshToken(string refreshToken);
    }
}
