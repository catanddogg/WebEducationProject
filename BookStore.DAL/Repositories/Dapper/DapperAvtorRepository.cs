using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BookStore.DAL.Repositories.Dapper
{
    public class DapperAvtorRepository : IAvtorRepository
    {
        private string _connectionString;
        public DapperAvtorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Avtor> GetAllAvtor()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                IEnumerable<Avtor> avtors = SqlMapperExtensions.GetAll<Avtor>(db);
                return avtors;
            }
        }

        public void CreateAvtor(Avtor avtor)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                SqlMapperExtensions.Insert(db, avtor);
                }
                catch(Exception ex)
                {

                }
            }
        }

        public void DeleteAvtor(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Avtor avtor = SqlMapperExtensions.Get<Avtor>(db, id);
                if(avtor != null)
                {
                    SqlMapperExtensions.Delete(db, avtor);
                }
            }
        }

        public IEnumerable<Avtor> GetAvtorBooks(string avtor)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                IEnumerable<Avtor> books = SqlMapperExtensions.GetAll<Avtor>(db).Where(x => x.NameAvtor == avtor);
                return books;
            }
        }

        public Avtor GetAvtorById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Avtor avtors = SqlMapperExtensions.Get<Avtor>(db, id);
                return avtors;
            }
        }

        public IEnumerable<Avtor> GetPublisherBooks(string publisher)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                IEnumerable<Avtor> res = SqlMapperExtensions.GetAll<Avtor>(db).Where(x => x.Publisher == publisher);
                return res;
            }
        }

        public void UpdateAvtor(Avtor avtor)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                SqlMapperExtensions.Update<Avtor>(db, avtor);
            }
        }
    }
}
