﻿using BookStore.DAL.Interfaces;
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
    public class PersonRepository : BaseRepository<BooksContext, Person>, IPersonRepository
    {
        private BooksContext _booksContext;
        public PersonRepository(BooksContext booksContext)
            : base(booksContext)
        {
            _booksContext = booksContext;
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
    }
}
