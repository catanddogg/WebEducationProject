using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.Dapper
{
    public class DapperBookRepository : BaseDapperRepository<Book>, IBookRepository
    {
        public DapperBookRepository(IDbConnection connectionString)
            : base(connectionString)
        {
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

        public Task<Book> GetBookById(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetBooksWIthAuthorAndCategories(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
