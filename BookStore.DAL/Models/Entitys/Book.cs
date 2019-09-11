using BookStore.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStore.DAL.Models
{
    [Table("Books")]
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        [Dapper.Contrib.Extensions.Computed]
        public virtual Author Author { get; set; }
        public List<Category> Category { get; set; }
    }
}
