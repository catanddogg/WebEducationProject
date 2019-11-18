using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.BaseViewModel
{
    public class BaseRequestViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
