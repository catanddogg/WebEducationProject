using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services.Services
{
    public class CommentService : ICommentService
    {
        #region Properties & Variables
        private readonly ICommentRepository _commentRepository;
        #endregion  Properties & Variables

        #region Constructors
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        #endregion Constructors

        #region Public Methods
        public void CreateAndGetAllComments(string UserName, string Comment)
        {
            _commentRepository.CreateAndGetAllComments(UserName, Comment);
        }
        #endregion Public Methods
    }
}
