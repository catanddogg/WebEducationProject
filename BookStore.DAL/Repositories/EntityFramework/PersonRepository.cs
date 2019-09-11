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
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(BooksContext booksContext)
            : base(booksContext)
        {
        }

        public async Task<Person> GetPersonByLoginAndPassword(string login, string password)
        {
            Person person = await _dbSet
                .Where(x => x.Login == login && x.Password == password)
                .SingleOrDefaultAsync();

            return person;
        }

        public async Task<Person> GetPersonByRefreshToken(string refreshToken)
        {
            Person person = await _dbSet
                .Where(x => x.RefreshToken == refreshToken)
                .SingleOrDefaultAsync();

            return person;
        }
    }
}
