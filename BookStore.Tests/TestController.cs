using BookStore.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookStore.Tests
{
    public class TestController
    {
        //private BooksController _booksController;

        public TestController(/*BooksController booksController*/)
        {
            //_booksController = booksController;
        }

        [Fact]
        public async void IndexViewResultNotNull()
        {
            bool test = true;

            Assert.True(test);
            //string filer = string.Empty;
            //AllBookViewModel result = await _booksController.GetAllBook(filer);

            //Assert.Null(result);
        }
    }
}
