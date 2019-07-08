using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services.Interfaces
{
    public interface ICommentService
    {
        void CreateAndGetAllComments(string UserName, string Comment);
    }
}
