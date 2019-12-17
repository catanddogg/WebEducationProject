using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public async Task CreateAndGetAllCommentsAsync(string UserName, string Comment)
        {
            await _commentRepository.CreateAndGetAllCommentsAsync(UserName, Comment);
        }
        #endregion Public Methods
    }
}
