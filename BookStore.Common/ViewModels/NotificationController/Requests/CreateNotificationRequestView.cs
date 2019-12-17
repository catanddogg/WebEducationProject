using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.NotificationController
{
    public class CreateNotificationRequestView
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Message { get; set; }
        public int PersonId { get; set; }
        public string Title { get; set; }
    }
}
