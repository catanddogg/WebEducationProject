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
        Task<AllBookViewModel> GetAllBookAsync(string filter);
        Task<BookViewModel> GetBookByIdAsync(int id);
        Task<BaseRequestViewModel> CreateBookAsync(BookViewModel model);
        Task DeleteBookAsync(int id);
        Task<BaseRequestViewModel> UpdateBookAsync(BookViewModel model);
    }
}
