using BookStore.DAL.Models.Base;
using BookStore.DAL.Models.Entitys;
using System;
using System.Collections.Generic;

namespace BookStore.DAL.Models
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }

        public Guid ResetPasswordToken { get;set; }
        public string RefreshToken { get; set; }

        public List<Notification> Notifications { get; set; }
        public List<Comment> Comments { get; set; }

        public User()
        {
            Notifications = new List<Notification>();
            Comments = new List<Comment>();
        }
    }
}
