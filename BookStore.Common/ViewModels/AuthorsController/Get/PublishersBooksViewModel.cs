﻿using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.AuthorsController.Get
{
    public class PublishersBooksViewModel
    {
        public List<PublishersBooksViewModelItemModel> publishersBooksViewModelItemModels { get; set; }
    }

    public class PublishersBooksViewModelItemModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string NameAuthor { get; set; }
        public string Publisher { get; set; }
    }
}
