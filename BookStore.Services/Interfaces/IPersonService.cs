using BookStore.Common.ViewModels.BaseViewModel;
using BookStore.Common.ViewModels.PersonController.Get;
using BookStore.Common.ViewModels.PersonController.Post;
using BookStore.Common.ViewModels.PersonController.Put;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IPersonService
    {
        Task<AllPersonViewModel> GetAllPerson();
        Task<BaseRequestViewModel> CreatePerson(CreateUserViewModel createPersonViewModel);
        void UpdatePerson(UpdatePersonViewModel updatePersonViewModel);
        void DeletePerson(int id);
        PersonByIdViewModel GetPersonById(int id);

        Task<LoginRequestViewModel> GetPersonByLoginAndPassword(string login, string password);
        Task<LoginRequestViewModel> GetPersonByRefreshToken(string refreshToken);
        Task<BaseRequestViewModel> SendEmailToRecoverPassword(SendEmailToRecoverPasswordViewModel model);
        Task<BaseRequestViewModel> ResetPassword(ResetPasswordViewModel model);
    }
}
