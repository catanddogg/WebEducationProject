using BookStore.DAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DAL.Models
{
    public class Comment : BaseEntity
    {
        public string Message { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}