using BookStore.Common.ViewModels.BaseViewModel;
using BookStore.Common.ViewModels.PersonController.Get;
using BookStore.Common.ViewModels.PersonController.Post;
using BookStore.Common.ViewModels.PersonController.Put;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IPersonService
    {
        Task<AllPersonViewModel> GetAllPersonAsync();
        Task<BaseRequestViewModel> CreatePersonAsync(CreateUserViewModel createPersonViewModel);
        Task UpdatePersonAsync(UpdatePersonViewModel updatePersonViewModel);
        Task DeletePersonAsync(int id);
        Task<PersonByIdViewModel> GetPersonByIdAsync(int id);
        Task<LoginRequestViewModel> GetPersonByLoginAndPasswordAsync(string login, string password);
        Task<LoginRequestViewModel> GetPersonByRefreshTokenAsync(string refreshToken);
        Task<BaseRequestViewModel> SendEmailToRecoverPasswordAsync(SendEmailToRecoverPasswordViewModel model);
        Task<BaseRequestViewModel> ResetPasswordAsync(ResetPasswordViewModel model);
    }
}
