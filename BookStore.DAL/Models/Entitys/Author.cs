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
        
        public int BookId { get; set; }

        //[Computed]
        //[ForeignKey("BookId")]
        public Book Book { get; set; }

        public string NameAuthor { get; set; }
        public string Publisher { get; set; }
    }
}
