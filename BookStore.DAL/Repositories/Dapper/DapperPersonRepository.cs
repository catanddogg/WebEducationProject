using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.DAL.Repositories.EntityFramework;
using Dapper.Contrib.Extensions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BookStore.DAL.Repositories.Dapper
{
    public class DapperPersonRepository : IPersonRepository
    {
        private string _connectionString;
        public DapperPersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreatePerson(Person person)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                SqlMapperExtensions.Insert(db, person);
            }
        }

        public void DeletePerson(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Person person = SqlMapperExtensions.Get<Person>(db, id);
                if(person != null)
                {
                    SqlMapperExtensions.Delete(db, person);
                }
            }
        }

        public IEnumerable<Person> GetAllPerson()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                IEnumerable<Person> people = SqlMapperExtensions.GetAll<Person>(db);
                return people;
            }
        }

        public Person GetPersonById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Person person = SqlMapperExtensions.Get<Person>(db, id);
                return person;
            }
        }

        public Person GetPersonByLoginAndPassword(string login, string password)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Person person = SqlMapperExtensions.GetAll<Person>(db).Where(x => x.Login == login && x.Password == password).SingleOrDefault();
                return person;
            }
        }

        public Person GetPersonByRefreshToken(string refreshToken)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Person person = SqlMapperExtensions.GetAll<Person>(db).Where(x => x.RefreshToken == refreshToken).SingleOrDefault();
                return person;
            }
        }

        public void UpdatePerson(Person person)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                SqlMapperExtensions.Update<Person>(db, person);
            }
        }

        private ClaimsIdentity GetIdentity(string login, string password)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Person person = SqlMapperExtensions.GetAll<Person>(db).Where(x => x.Login == login && x.Password == password).SingleOrDefault();
                if (person != null)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                    ClaimsIdentity claimsIdentity =
                        new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                    return claimsIdentity;
                }
                return null;
            }
        }
    }
}
