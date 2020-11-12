using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DAL.Models.Entitys
{
    public class CategoryInBook
    {
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}
