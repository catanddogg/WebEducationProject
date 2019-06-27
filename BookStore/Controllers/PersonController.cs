using System.Collections.Generic;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using BookStore.Services.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        //GET : api/persom/gettoken
        [HttpGet("{gettoken}")]
        public JWTAndRefreshToken Login(string login, string password)
        {
            Person person = _personService.GetPersonByLoginAndPassword(login, password);
            if(person == null)
            {
                return null;
            }
            JWTAndRefreshToken jWTAndRefreshToken = JWTManager.Login(person.Login, person.Password);
            return jWTAndRefreshToken;
        }

        //GET : api/person/refreshtoken
        [HttpGet("{refreshtoken}")]
        public JWTAndRefreshToken RefreshToken(string refreshToken)
        {
            Person person = _personService.GetPersonByRefreshToken(refreshToken);
            if(person == null)
            {
                return null;
            }
            JWTAndRefreshToken jWTAndRefreshToken = JWTManager.Login(person.Login, person.Password);
            return jWTAndRefreshToken;
        }

        //GET : api/person
        [Authorize]
        [HttpGet]
        public IEnumerable<Person> GetAllPeople()
        {
            return _personService.GetAllPerson();
        }

        //GET : api/person/id
        [Authorize]
        [HttpGet("{id}")]
        public Person GetPersonById(int id)
        {
            return _personService.GetPersonById(id);
        }

        //POST : api/person
        [Authorize]
        [HttpPost]
        public void CreatePerson(Person person)
        {
            _personService.CreatePerson(person);
        }

        //PUT : api/person
        [Authorize]
        [HttpPut]
        public void UpdatePerson(Person person)
        {
            _personService.UpdatePerson(person);
        }

        //DELETE : api/person/{id}
        [Authorize]
        [HttpDelete("{id}")]
        public void DeletePerson(int id)
        {
            _personService.DeletePerson(id);
        }
    }
}