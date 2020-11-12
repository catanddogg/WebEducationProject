using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.Dapper
{
    public class DapperPersonRepository : BaseDapperRepository<User>, IPersonRepository
    {
        public DapperPersonRepository(IDbConnection connectionString)
            :base(connectionString)
        {
        }

        public async Task<bool> CheckReduplicationEmailAsync(string email)
        {
            IEnumerable<User> query = await _connectionString
                .QueryAsync<User>($"SELECT * FROM Persons AS p" +
                                    $"WHERE p.Login = {email}");

            return query.Any();
        }

        public async Task<bool> CheckReduplicationUserNameAsync(string userName)
        {
            IEnumerable<User> query = await _connectionString
                .QueryAsync<User>($"SELECT * FROM Persons AS p" +
                                    $"WHERE p.FirstName = {userName}");

            return query.Any();
        }

        public async Task<User> GetPersonByEmailAsync(string email)
        {
            IEnumerable<User> query = await _connectionString
                .QueryAsync<User>($"SELECT * FROM Persons as p" +
                                    $"WHERE p.Login = {email}");

            return query.SingleOrDefault();
        }

        public async Task<User> GetPersonByLoginAndPasswordAsync(string login, string password)
        {
            User person = await SqlMapperExtensions
                .GetAll<User>(_connectionString)
                .Where(x => x.Login == login && x.Password == password)
                .AsQueryable()
                .SingleOrDefaultAsync();

            return person;
        }

        public async Task<User> GetPersonByRefreshTokenAsync(string refreshToken)
        {
            User person = await SqlMapperExtensions
                .GetAll<User>(_connectionString)
                .Where(x => x.RefreshToken == refreshToken)
                .AsQueryable()
                .FirstOrDefaultAsync();

            return person;
        }

        public async Task<bool> ResetPasswordAsync(string password, string resetPasswordGuid)
        {
            //TODO testing
            IEnumerable<bool> test = await _connectionString
                .QueryAsync<bool>($"UPDATE Book.dbo.Persons " +
                                  $"SET ResetPasswordToken = '00000000-0000-0000-0000-000000000000'," +
                                  $" Password = {password} WHERE ResetPasswordToken = {resetPasswordGuid}");          

            return test.FirstOrDefault();
        }
    }
}
