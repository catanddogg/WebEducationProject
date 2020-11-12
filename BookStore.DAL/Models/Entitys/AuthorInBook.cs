using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DAL.Models.Entitys
{
    public class AuthorInBook
    {
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}