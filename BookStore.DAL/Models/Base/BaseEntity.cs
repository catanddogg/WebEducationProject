using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStore.DAL.Models.Base
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public DateTime CreationDate { get; set; }

        //public BaseEntity()
        //{
        //    CreationDate = DateTime.UtcNow;
        //}
    }
}
