using System.Threading.Tasks;
using BookStore.Common.ViewModels.BaseViewModel;
using BookStore.Common.ViewModels.PersonController.Get;
using BookStore.Common.ViewModels.PersonController.Post;
using BookStore.Common.ViewModels.PersonController.Put;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AddTestCors")]
    [Authorize]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<LoginRequestViewModel> Login(LoginViewModel model)
        {
            LoginRequestViewModel result  = await _personService.GetPersonByLoginAndPasswordAsync(model.UserName, model.Password);

            return result;
        }

        [AllowAnonymous]
        [HttpPost("RefreshToken")]
        public async Task<LoginRequestViewModel> RefreshToken(RefreshTokenViewModel model)
        {
            LoginRequestViewModel result = await _personService.GetPersonByRefreshTokenAsync(model.RefreshToken);

            return result;
        } 

        [AllowAnonymous]
        [HttpPost("SendEmailToRecoverPassword")]
        public async Task<BaseRequestViewModel> SendEmailToRecoverPassword(SendEmailToRecoverPasswordViewModel model)
        {
            BaseRequestViewModel result = await _personService.SendEmailToRecoverPasswordAsync(model);

            return result;
        }

        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public async Task<BaseRequestViewModel> ResetPassword(ResetPasswordViewModel model)
        {
            BaseRequestViewModel result = await _personService.ResetPasswordAsync(model);

            return result;
        }

        [HttpGet("GetAllPeople")]
        public async Task<AllPersonViewModel> GetAllPeople()
        {
            AllPersonViewModel result = await _personService.GetAllPersonAsync();

            return result;
        }

        [HttpGet("GetPersonById/{id}")]
        public async Task<PersonByIdViewModel> GetPersonById(int id)
        {
            PersonByIdViewModel result = await _personService.GetPersonByIdAsync(id);

            return result;
        }      

        [HttpPost("CreateUser")]
        [AllowAnonymous]
        public async Task<BaseRequestViewModel> CreateUser([FromBody]CreateUserViewModel model)
        {
            BaseRequestViewModel result = await _personService.CreatePersonAsync(model);

            return result;
        }

        [HttpPut("UpdatePerson")]
        public async Task UpdatePerson(UpdatePersonViewModel updatePersonViewModel)
        {
            await _personService.UpdatePersonAsync(updatePersonViewModel);
        }

        [HttpDelete("DeletePerson/{id}")]
        public async Task DeletePerson(int id)
        {
            await _personService.DeletePersonAsync(id);
        }
    }
}