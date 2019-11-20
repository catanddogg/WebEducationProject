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

        public async Task<bool> CheckReduplicationUserName(string userName)
        {
            bool isRegistered = await _dbSet
                .Where(item => item.FirstName == userName)
                .AnyAsync();

            return isRegistered;
        }

        public async Task<bool> CheckReduplicationEmail(string email)
        {
            bool isEmailRegistered = await _dbSet
                .Where(item => item.Login == email)
                .AnyAsync();

            return isEmailRegistered;
        }

        public async Task<Person> GetPersonByEmail(string email)
        {
            Person result = await _dbSet
                .Where(item => item.Login == email)
                .SingleOrDefaultAsync();

            if(result == null)
            {
                return result;
            }

            Guid resetPasswordToken = Guid.NewGuid();

            result.ResetPasswordToken = resetPasswordToken;

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<bool> ResetPassword(string password, string resetPasswordGuid)
        {
            Person person = await _dbSet
                .Where(item => item.ResetPasswordToken == Guid.Parse(resetPasswordGuid))
                .SingleOrDefaultAsync();

            if(person == null)
            {
                return false;
            }

            person.Password = password;
            person.ResetPasswordToken = default(Guid);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
