using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {

        public CommentRepository(BooksContext bookContext)
            : base(bookContext)
        {
        }

        public async Task CreateAndGetAllCommentsAsync(string UserName, string Comment)
        {
            Comment comment = new Comment() { Message = Comment, CreationDate = DateTime.Now };

            _dbSet.Add(comment);

            await _context.SaveChangesAsync();
        }
    }
}
