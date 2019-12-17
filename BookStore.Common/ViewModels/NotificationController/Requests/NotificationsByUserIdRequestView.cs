using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.NotificationController
{
    public class NotificationsByUserIdRequestView
    {
        public List<NotificationsByUserIdViewItem> Notifications { get; set; }

        public NotificationsByUserIdRequestView()
        {
            Notifications = new List<NotificationsByUserIdViewItem>();
        }
    }

    public class NotificationsByUserIdViewItem
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
    }
}
