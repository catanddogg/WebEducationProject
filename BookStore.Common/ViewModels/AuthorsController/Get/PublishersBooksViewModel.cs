using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.AuthorsController.Get
{
    public class PublishersBooksViewModel
    {
        public List<PublishersBooksViewModelItem> Publishers { get; set; }

        public PublishersBooksViewModel()
        {
            Publishers = new List<PublishersBooksViewModelItem>();
        }
    }

    public class PublishersBooksViewModelItem
    {
        public string NameAuthor { get; set; }
        public string Publisher { get; set; }
    }
}
