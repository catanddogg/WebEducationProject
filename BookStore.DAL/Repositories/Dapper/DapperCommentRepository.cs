using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Dapper.Contrib.Extensions;
using System;
using System.Data;

namespace BookStore.DAL.Repositories.Dapper
{
    public class DapperCommentRepository : BaseDapperRepository<Comment>, ICommentRepository
    {
        public DapperCommentRepository(IDbConnection connectionString)
            : base(connectionString)
        {
        }

        public void CreateAndGetAllComments(string UserName, string Comment)
        {
            Comment comment = new Comment() { UserName = UserName, Message = Comment, CreateDateTime = DateTime.Now };

            _connectionString.Insert(comment);
        }  
    }
}
