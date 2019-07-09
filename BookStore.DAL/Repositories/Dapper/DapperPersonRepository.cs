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
    public class DapperPersonRepository : BaseDapperRepository< Person>, IPersonRepository
    {
        private IDbConnection _connectionString;
        public DapperPersonRepository(IDbConnection connectionString)
            :base(connectionString)
        {
            _connectionString = connectionString;
        }

        //public void CreatePerson(Person person)
        //{
        //    SqlMapperExtensions.Insert(_connectionString, person);
        //}

        //public void DeletePerson(int id)
        //{
        //    Person person = SqlMapperExtensions.Get<Person>(_connectionString, id);
        //    if (person != null)
        //    {
        //        SqlMapperExtensions.Delete(_connectionString, person);
        //    }
        //}

        //public IEnumerable<Person> GetAllPerson()
        //{
        //    IEnumerable<Person> people = SqlMapperExtensions.GetAll<Person>(_connectionString);
        //    return people;
        //}

        //public Person GetPersonById(int id)
        //{
        //    Person person = SqlMapperExtensions.Get<Person>(_connectionString, id);
        //    return person;
        //}

        public Person GetPersonByLoginAndPassword(string login, string password)
        {
            Person person = SqlMapperExtensions.GetAll<Person>(_connectionString).Where(x => x.Login == login && x.Password == password).SingleOrDefault();
            return person;
        }

        public Person GetPersonByRefreshToken(string refreshToken)
        {
            Person person = SqlMapperExtensions.GetAll<Person>(_connectionString).Where(x => x.RefreshToken == refreshToken).SingleOrDefault();
            return person;
        }

        //public void UpdatePerson(Person person)
        //{
        //    SqlMapperExtensions.Update<Person>(_connectionString, person);
        //}       
    }
}
