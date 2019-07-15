﻿using BookStore.DAL.Interfaces;
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

        public CategoriesBooksAvtors GetAllTables()
        {
            IEnumerable<Book> books = SqlMapperExtensions.GetAll<Book>(_connectionString);
            IEnumerable<Author> authors = SqlMapperExtensions.GetAll<Author>(_connectionString);
            IEnumerable<Category> categories = SqlMapperExtensions.GetAll<Category>(_connectionString);
            IEnumerable<Comment> comments = SqlMapperExtensions.GetAll<Comment>(_connectionString);

            CategoriesBooksAvtors categoriesBooksAvtors = new CategoriesBooksAvtors();
            categoriesBooksAvtors.Books.AddRange(books);
            categoriesBooksAvtors.Avtors.AddRange(authors);
            categoriesBooksAvtors.Categories.AddRange(categories);
            categoriesBooksAvtors.Comments.AddRange(comments);

            return categoriesBooksAvtors;
        }
    }
}
