using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.AuthorsController.Get
{
    public class AllAuthorViewModel
    {
        public List<AllAuthorViewModelItem> Authors { get; set; } 

        public AllAuthorViewModel()
        {
            Authors = new List<AllAuthorViewModelItem>();
        }
    }

    public class AllAuthorViewModelItem
    {
        public string NameAuthor { get; set; }
        public string Publisher { get; set; }
    }
}
