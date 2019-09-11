using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.DAL.Repositories.EntityFramework;
using Dapper.Contrib.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.Dapper
{
    public class DapperPersonRepository : BaseDapperRepository< Person>, IPersonRepository
    {
        public DapperPersonRepository(IDbConnection connectionString)
            :base(connectionString)
        {
        }

        public async Task<Person> GetPersonByLoginAndPassword(string login, string password)
        {
            Person person = await SqlMapperExtensions
                .GetAll<Person>(_connectionString)
                .Where(x => x.Login == login && x.Password == password)
                .AsQueryable()
                .SingleOrDefaultAsync();

            return person;
        }

        public async Task<Person> GetPersonByRefreshToken(string refreshToken)
        {
            Person person = await SqlMapperExtensions
                .GetAll<Person>(_connectionString)
                .Where(x => x.RefreshToken == refreshToken)
                .AsQueryable()
                .FirstOrDefaultAsync();

            return person;
        }
    }
}
