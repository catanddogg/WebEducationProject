using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.DAL.Repositories.EntityFramework;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BookStore.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void CreatePerson(Person person)
        {
            _personRepository.CreatePerson(person);
        }

        public void DeletePerson(int id)
        {
            _personRepository.DeletePerson(id);
        }

        public IEnumerable<Person> GetAllPerson()
        {
            return _personRepository.GetAllPerson();
        }

        public Person GetPersonById(int id)
        {
            return _personRepository.GetPersonById(id);
        }

        public Person GetPersonByLoginAndPassword(string login, string password)
        {
            return _personRepository.GetPersonByLoginAndPassword(login, password);
        }

        public Person GetPersonByRefreshToken(string refreshToken)
        {
            return _personRepository.GetPersonByRefreshToken(refreshToken);
        }

        public void UpdatePerson(Person person)
        {
            _personRepository.UpdatePerson(person);
        }
    }
}
