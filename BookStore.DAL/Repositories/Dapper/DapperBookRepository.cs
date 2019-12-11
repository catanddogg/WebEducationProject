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
            var sql =@"SELECT * FROM Books 
                       SELECT * FROM Avtors 
                       SELECT * FROM Comments 
                       SELECT * FROM categories";

            using (SqlMapper.GridReader multi = _connectionString.QueryMultiple(sql))
            {
                categoriesBooksAuthors.Books = multi.Read<Book>().ToList();
                categoriesBooksAuthors.Authors = multi.Read<Author>().ToList();
                categoriesBooksAuthors.Categories = multi.Read<Category>().ToList();
                categoriesBooksAuthors.Comments = multi.Read<Comment>().ToList();
            }

            return categoriesBooksAuthors;
        }

        public async Task<Book> GetBookById(int bookId)
        {
            IEnumerable<Book> query = await _connectionString
                .QueryAsync<Book>(@"SELECT * FROM Books AS b
                                  LEFT JOIN Avtors AS a
                                  ON b.AuthorId = a.Id
                                  LEFT JOIN Categories AS c
                                  ON b.CategoryId = c.Id 
                                  WHERE b.Id = {bookId}");

            Book result = query.FirstOrDefault();

            return result;
        }

        public async Task<List<Book>> GetBooksWIthAuthorAndCategories(string filter)
        {
            var query = await _connectionString
                .QueryAsync<Book>(@"SELECT * FROM Books AS b
                                  LEFT JOIN Avtors a 
                                  ON b.AuthorId = a.Id 
                                  LEFT JOIN Categories AS c 
                                  ON b.CategoryId = c.Id 
                                  WHERE b.Name LIKE '%{filter}%' 
                                  OR a.NameAuthor LIKE '%{filter}%' 
                                  OR a.Publisher LIKE '%{filter}%'");

            List<Book> result = query.ToList();

            return result;
        }
    }
}
