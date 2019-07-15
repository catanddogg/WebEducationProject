using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.AuthorsController.Get
{
    public class AuthorBooksViewModel
    {
        public List<AuthorBooksViewModelItemModel> authorsBookViewModelItemModels { get; set; }
    }

    public class AuthorBooksViewModelItemModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string NameAuthor { get; set; }
        public string Publisher { get; set; }
    }
}
