using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BookStore.DAL.Repositories.Dapper
{
    public class DapperCommentRepository : ICommentRepository
    {
        private string _connectionString;

        public DapperCommentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateAndGetAllComments(string UserName, string Comment)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Comment comment = new Comment() { UserName = UserName, Message = Comment, createTime = DateTime.Now };
                SqlMapperExtensions.Insert(db, comment);
            }
        }
    }
}
