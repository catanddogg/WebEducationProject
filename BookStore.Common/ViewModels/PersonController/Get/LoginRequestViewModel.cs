using BookStore.Common.ViewModels.BaseViewModel;

namespace BookStore.Common.ViewModels.PersonController.Get
{
    public class LoginRequestViewModel : BaseRequestViewModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string UserName { get; set; }
    }
}
