using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.AuthorsController.Get
{
    public class AuthorBooksViewModel
    {
        public List<AuthorBooksViewModelItem> AuthorBooks { get; set; }

        public AuthorBooksViewModel()
        {
            AuthorBooks = new List<AuthorBooksViewModelItem>();
        }
    }

    public class AuthorBooksViewModelItem
    {
        public string NameAuthor { get; set; }
        public string Publisher { get; set; }
    }
}
