using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using System.Linq;
using BookStore.DAL.Enums;
using Dapper;

namespace BookStore.DAL.Repositories.Dapper
{
    public class DapperBookRepository : BaseDapperRepository<Book>, IBookRepository
    {
        private IDbConnection _connectionString;
        
        public DapperBookRepository(IDbConnection connectionString)
            : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public CategoriesBooksAuthorsDTO GetAllTables()
        {
            var categoriesBooksAuthors = new CategoriesBooksAuthorsDTO();
            var sql =
                    @"
                    select * from Books 
                    select * from Avtors 
                    select * from Comments 
                    select * from categories";

            using (SqlMapper.GridReader multi = _connectionString.QueryMultiple(sql))
            {
                categoriesBooksAuthors.Books = multi.Read<Book>().ToList();
                categoriesBooksAuthors.Authors = multi.Read<Author>().ToList();
                categoriesBooksAuthors.Categories = multi.Read<Category>().ToList();
                categoriesBooksAuthors.Comments = multi.Read<Comment>().ToList();
            }

            return categoriesBooksAuthors;
        }
    }
}
