using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {

        public CommentRepository(BooksContext bookContext)
            : base(bookContext)
        {
        }

        public void CreateAndGetAllComments(string UserName, string Comment)
        {
            Comment comment = new Comment() { Message = Comment, UserName = UserName, CreateDateTime = DateTime.Now };

            _dbSet.Add(comment);

            _context.SaveChanges();
        }
    }
}
