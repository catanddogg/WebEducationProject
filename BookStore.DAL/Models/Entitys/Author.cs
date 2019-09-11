using BookStore.DAL.Models.Base;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStore.DAL.Models
{
    public class Author : BaseEntity
    {
        public List<Book> Books { get; set; }

        public string NameAuthor { get; set; }
        public string Publisher { get; set; }
    }
}
