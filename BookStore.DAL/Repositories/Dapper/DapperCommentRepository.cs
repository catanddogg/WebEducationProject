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
    public class DapperCommentRepository : BaseDapperRepository<Comment>, ICommentRepository
    {
        private IDbConnection _connectionString;
        public DapperCommentRepository(IDbConnection connectionString)
            : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateAndGetAllComments(string UserName, string Comment)
        {
            Comment comment = new Comment() { UserName = UserName, Message = Comment, createTime = DateTime.Now };
            SqlMapperExtensions.Insert(_connectionString, comment);
        }
    }
}
