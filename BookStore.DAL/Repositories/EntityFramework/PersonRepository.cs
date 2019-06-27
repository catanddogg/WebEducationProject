using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class PersonRepository : IPersonRepository
    {
        private BooksContext _booksContext;
        public PersonRepository(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        public void CreatePerson(Person person)
        {
            _booksContext.Add(person);
            _booksContext.SaveChanges();
        }

        public void DeletePerson(int id)
        {
            Person person = _booksContext.Find<Person>(id);
            if(person != null)
            {
                _booksContext.Remove(person);
                _booksContext.SaveChanges();
            }
        }

        public IEnumerable<Person> GetAllPerson()
        {
            DbSet<Person> persons = _booksContext.Set<Person>();
            return persons;
        }

        public Person GetPersonById(int id)
        {
            Person person = _booksContext.Find<Person>(id);
            return person;
        }

        public Person GetPersonByLoginAndPassword(string login, string password)
        {
            Person person = _booksContext.Persons.Where(x => x.Login == login && x.Password == password).SingleOrDefault();
            return person;
        }

        public Person GetPersonByRefreshToken(string refreshToken)
        {
            Person person = _booksContext.Persons.Where(x => x.RefreshToken == refreshToken).SingleOrDefault();
            return person;
        }

        public void UpdatePerson(Person person)
        {
            _booksContext.Entry(person).State = EntityState.Modified;
            _booksContext.SaveChanges();
        }      
    }
}
