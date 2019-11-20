using System.Threading.Tasks;
using BookStore.Common.ViewModels.BaseViewModel;
using BookStore.Common.ViewModels.PersonController.Get;
using BookStore.Common.ViewModels.PersonController.Post;
using BookStore.Common.ViewModels.PersonController.Put;
using BookStore.DAL.Models;
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
        private readonly IJWTService _jWTService;

        public PersonController(IPersonService personService, IJWTService jWTService)
        {
            _jWTService = jWTService;
            _personService = personService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<LoginRequestViewModel> Login(LoginViewModel model)
        {
            LoginRequestViewModel result  = await _personService.GetPersonByLoginAndPassword(model.UserName, model.Password);

            return result;
        }

        [AllowAnonymous]
        [HttpPost("RefreshToken")]
        public async Task<LoginRequestViewModel> RefreshToken(RefreshTokenViewModel model)
        {
            LoginRequestViewModel result = await _personService.GetPersonByRefreshToken(model.RefreshToken);

            return result;
        } 

        [AllowAnonymous]
        [HttpPost("SendEmailToRecoverPassword")]
        public async Task<BaseRequestViewModel> SendEmailToRecoverPassword(SendEmailToRecoverPasswordViewModel model)
        {
            BaseRequestViewModel result = await _personService.SendEmailToRecoverPassword(model);

            return result;
        }

        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public async Task<BaseRequestViewModel> ResetPassword(ResetPasswordViewModel model)
        {
            BaseRequestViewModel result = await _personService.ResetPassword(model);

            return result;
        }

        [HttpGet("GetAllPeople")]
        public async Task<AllPersonViewModel> GetAllPeople()
        {
            AllPersonViewModel result = await _personService.GetAllPerson();

            return result;
        }

        [HttpGet("GetPersonById/{id}")]
        public PersonByIdViewModel GetPersonById(int id)
        {
            PersonByIdViewModel result  = _personService.GetPersonById(id);

            return result;
        }      

        [HttpPost("CreateUser")]
        [AllowAnonymous]
        public async Task<BaseRequestViewModel> CreateUser([FromBody]CreateUserViewModel model)
        {
            BaseRequestViewModel result = await _personService.CreatePerson(model);

            return result;
        }

        [HttpPut("UpdatePerson")]
        public void UpdatePerson(UpdatePersonViewModel updatePersonViewModel)
        {
            _personService.UpdatePerson(updatePersonViewModel);
        }

        [HttpDelete("DeletePerson/{id}")]
        public void DeletePerson(int id)
        {
            _personService.DeletePerson(id);
        }
    }
}