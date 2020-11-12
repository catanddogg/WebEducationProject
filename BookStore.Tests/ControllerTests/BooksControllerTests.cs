using BookStore.Common.ViewModels.BooksController.Get;
using BookStore.Controllers;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using BookStore.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookStore.Tests.ControllerTests
{
    public class BooksControllerTests
    {
        private BooksController _booksController;
        private BookService _bookService;

        public BooksControllerTests()
        {
            var _bookService = new Mock<IBookService>();
            //_bookService.Setup(repo => repo.GetAllBookAsync(string.Empty)).Returns(GetTestUsers());
            _booksController = new BooksController(_bookService.Object);
        }

        [Fact]
        public async void test()
        {
            //bool test = true;

            //Assert.True(test);
            //AllBookViewModel result = await _booksController.GetAllBook(string.Empty);
            Book book = new Book();

            Assert.NotNull(book);
            // Arrange
            //BooksController controller = new BooksController();
            //// Act
            //ViewResult result = controller.Index() as ViewResult;
            //// Assert
            //Assert.NotNull(result);
        }

        [Fact]
        public async void TestGetBookById()
        {
            BookViewModel result = await _booksController.GetBookById(4);

            Assert.NotNull(result);
        }

    }
}
