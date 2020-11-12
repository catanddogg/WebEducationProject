using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Dapper.Contrib.Extensions;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.Dapper
{
    public class DapperCommentRepository : BaseDapperRepository<Comment>, ICommentRepository
    {
        public DapperCommentRepository(IDbConnection connectionString)
            : base(connectionString)
        {
        }

        public async Task CreateAndGetAllCommentsAsync(string UserName, string Comment)
        {
            Comment comment = new Comment() { Message = Comment, CreationDate = DateTime.Now };

            await _connectionString.InsertAsync(comment);
        }  
    }
}
