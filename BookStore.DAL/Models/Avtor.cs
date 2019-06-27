using BookStore.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStore.DAL.Models
{
    [Table("Avtors")]
    public class Avtor : BaseEntity
    {
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        public string NameAvtor { get; set; }
        public string Publisher { get; set; }
    }
}
