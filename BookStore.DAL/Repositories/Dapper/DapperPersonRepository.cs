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
    public class DapperPersonRepository : BaseDapperRepository<Person>, IPersonRepository
    {
        public DapperPersonRepository(IDbConnection connectionString)
            :base(connectionString)
        {
        }

        public async Task<bool> CheckReduplicationEmailAsync(string email)
        {
            IEnumerable<Person> query = await _connectionString
                .QueryAsync<Person>($"SELECT * FROM Persons AS p" +
                                    $"WHERE p.Login = {email}");

            return query.Any();
        }

        public async Task<bool> CheckReduplicationUserNameAsync(string userName)
        {
            IEnumerable<Person> query = await _connectionString
                .QueryAsync<Person>($"SELECT * FROM Persons AS p" +
                                    $"WHERE p.FirstName = {userName}");

            return query.Any();
        }

        public async Task<Person> GetPersonByEmailAsync(string email)
        {
            IEnumerable<Person> query = await _connectionString
                .QueryAsync<Person>($"SELECT * FROM Persons as p" +
                                    $"WHERE p.Login = {email}");

            return query.SingleOrDefault();
        }

        public async Task<Person> GetPersonByLoginAndPasswordAsync(string login, string password)
        {
            Person person = await SqlMapperExtensions
                .GetAll<Person>(_connectionString)
                .Where(x => x.Login == login && x.Password == password)
                .AsQueryable()
                .SingleOrDefaultAsync();

            return person;
        }

        public async Task<Person> GetPersonByRefreshTokenAsync(string refreshToken)
        {
            Person person = await SqlMapperExtensions
                .GetAll<Person>(_connectionString)
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
