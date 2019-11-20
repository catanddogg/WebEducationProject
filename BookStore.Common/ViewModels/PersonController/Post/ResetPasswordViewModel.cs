using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Common.ViewModels.PersonController.Post
{
    public class ResetPasswordViewModel
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ResetPasswordToken { get; set; }
    }
}
