using System.Collections.Generic;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
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

        //GET : api/person/gettoken
        [AllowAnonymous]
        [HttpGet("{gettoken}")]
        public JWTAndRefreshToken Login(string login, string password)
        {
            Person person = _personService.GetPersonByLoginAndPassword(login, password);
            if (person == null)
            {
                return null;
            }
            JWTAndRefreshToken jWTAndRefreshToken = _jWTService.Login(person.Login, person.Password);
            return jWTAndRefreshToken;
        }

        //GET : api/person/refreshtoken
        [AllowAnonymous]
        [HttpGet("{refreshtoken}")]
        public JWTAndRefreshToken RefreshToken(string refreshToken)
        {
            Person person = _personService.GetPersonByRefreshToken(refreshToken);
            if(person == null)
            {
                return null;
            }
            JWTAndRefreshToken jWTAndRefreshToken = _jWTService.Login(person.Login, person.Password);
            return jWTAndRefreshToken;
        }

        //GET : api/person
        [HttpGet]
        public IEnumerable<Person> GetAllPeople()
        {
            return _personService.GetAllPerson();
        }

        //GET : api/person/id
        [HttpGet("{id}")]
        public Person GetPersonById(int id)
        {
            return _personService.GetPersonById(id);
        }

        //POST : api/person
        [HttpPost]
        public void CreatePerson(Person person)
        {
            _personService.CreatePerson(person);
        }

        //PUT : api/person
        [HttpPut]
        public void UpdatePerson(Person person)
        {
            _personService.UpdatePerson(person);
        }

        //DELETE : api/person/{id}
        [HttpDelete("{id}")]
        public void DeletePerson(int id)
        {
            _personService.DeletePerson(id);
        }
    }
}