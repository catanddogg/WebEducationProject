using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Interfaces
{
    public interface ICommentRepository
    {
        void CreateAndGetAllComments(string UserName, string Comment);
    }
}
