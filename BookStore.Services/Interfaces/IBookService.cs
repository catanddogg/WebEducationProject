using BookStore.Common.ViewModels.BooksController.Get;
using BookStore.Common.ViewModels.BooksController.Post;
using BookStore.Common.ViewModels.BooksController.Put;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services.Interfaces
{
    public interface IBookService
    {
        AllBookViewModel GetAllBook();
        BookByIdViewModel GetBookById(int id);
        void CreateBook(CreateBookViewModel createBookViewModel);
        void DeleteBook(int id);
        void UpdateBook(UpdateBookViewModel updateBookViewModel);

        CategoriesBooksAuthors GetAllTables();
    }
}
