using BookStore.Common.ViewModels.BaseViewModel;
using BookStore.Common.ViewModels.BooksController.Get;
using BookStore.Common.ViewModels.BooksController.Post;
using BookStore.Common.ViewModels.BooksController.Put;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IBookService
    {
        Task<AllBookViewModel> GetAllBook(string filter);
        Task<BookViewModel> GetBookById(int id);
        BaseRequestViewModel CreateBook(BookViewModel model);
        void DeleteBook(int id);
        BaseRequestViewModel UpdateBook(BookViewModel model);
    }
}
