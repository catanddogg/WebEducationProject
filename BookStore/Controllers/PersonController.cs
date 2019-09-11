using System.Threading.Tasks;
using BookStore.Common.ViewModels.PersonController.Get;
using BookStore.Common.ViewModels.PersonController.Post;
using BookStore.Common.ViewModels.PersonController.Put;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
        [HttpGet("Login/{gettoken}")]
        public async Task<JWTAndRefreshToken> Login(string login, string password)
        {
            Person person = await _personService.GetPersonByLoginAndPassword(login, password);

            if (person == null)
            {
                return null;
            }
            JWTAndRefreshToken jWTAndRefreshToken = await _jWTService.Login(person.Login, person.Password);

            return jWTAndRefreshToken;
        }

        [AllowAnonymous]
        [HttpGet("RefreshToken/{refreshtoken}")]
        public async Task<JWTAndRefreshToken> RefreshToken(string refreshToken)
        {
            Person person = await _personService.GetPersonByRefreshToken(refreshToken);
            if(person == null)
            {
                return null;
            }
            JWTAndRefreshToken jWTAndRefreshToken = await _jWTService.Login(person.Login, person.Password);

            return jWTAndRefreshToken;
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

        [HttpPost("CreatePerson")]
        public void CreatePerson(CreatePersonViewModel createPersonViewModel)
        {
            _personService.CreatePerson(createPersonViewModel);
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