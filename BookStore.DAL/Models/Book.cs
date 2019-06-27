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
    }
}
