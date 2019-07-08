using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Repositories.EntityFramework
{
    public class CommentRepository : ICommentRepository
    {
        private BooksContext _context;

        public CommentRepository(BooksContext context)
        {
            _context = context;
        }

        public void CreateAndGetAllComments(string UserName, string Comment)
        {
            Comment comment = new Comment() { Message = Comment, UserName = UserName, createTime = DateTime.Now };
            _context.Add(comment);
            _context.SaveChanges();
        }
    }
}
