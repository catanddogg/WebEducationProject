using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class CommentRepository : BaseRepository<BooksContext, Comment>, ICommentRepository
    {
        private BooksContext _bookContext;

        public CommentRepository(BooksContext bookContext)
            : base(bookContext)
        {
            _bookContext = bookContext;
        }

        public void CreateAndGetAllComments(string UserName, string Comment)
        {
            Comment comment = new Comment() { Message = Comment, UserName = UserName, createTime = DateTime.Now };
            _bookContext.Add(comment);
            _bookContext.SaveChanges();
        }
    }
}
