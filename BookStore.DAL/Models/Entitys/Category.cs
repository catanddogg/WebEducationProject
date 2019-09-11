using BookStore.DAL.Enums;
using BookStore.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStore.DAL.Models
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [Dapper.Contrib.Extensions.Computed]
        public virtual Book Book { get; set; }

        public CategoryType FirstCategoryType { get; set; }
        public CategoryType SecondCategoryType { get; set; }
        public CategoryType TrirdCategoryType { get; set; }
    }
}
