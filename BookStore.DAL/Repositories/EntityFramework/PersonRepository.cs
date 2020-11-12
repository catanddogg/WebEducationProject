using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class PersonRepository : BaseRepository<User>, IPersonRepository
    {
        public PersonRepository(BooksContext booksContext)
            : base(booksContext)
        {
        }

        public async Task<User> GetPersonByLoginAndPasswordAsync(string login, string password)
        {
            User person = await _dbSet
                .Where(x => x.Login == login && x.Password == password)
                .SingleOrDefaultAsync();

            return person;
        }

        public async Task<User> GetPersonByRefreshTokenAsync(string refreshToken)
        {
            User person = await _dbSet
                .Where(x => x.RefreshToken == refreshToken)
                .SingleOrDefaultAsync();

            return person;
        }

        public async Task<bool> CheckReduplicationUserNameAsync(string userName)
        {
            bool isRegistered = await _dbSet
                .Where(item => item.FirstName == userName)
                .AnyAsync();

            return isRegistered;
        }

        public async Task<bool> CheckReduplicationEmailAsync(string email)
        {
            bool isEmailRegistered = await _dbSet
                .Where(item => item.Login == email)
                .AnyAsync();

            return isEmailRegistered;
        }

        public async Task<User> GetPersonByEmailAsync(string email)
        {
            User result = await _dbSet
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

        public async Task<bool> ResetPasswordAsync(string password, string resetPasswordGuid)
        {
            User person = await _dbSet
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
