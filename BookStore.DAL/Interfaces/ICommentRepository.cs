using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task CreateAndGetAllCommentsAsync(string UserName, string Comment);
    }
}
