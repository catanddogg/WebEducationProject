using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BookStore.Common.ViewModels;
using BookStore.DAL.Enums;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly IJWTService _jWTService;

        public HomeController(IJWTService jWTService, IHomeService homeService)
        {
            _homeService = homeService;
            _jWTService = jWTService;
        }

        public IActionResult Index()
        {
            return View(_homeService.GetAllTables());
        }
     
        [HttpPost]
        public IActionResult Index([FromForm]TypeTable typeTable)
        {
            ViewBag.TypeTable = typeTable.ToString();
            return PartialView("Views/Home/Index.cshtml", _homeService.GetAllTables());
        }

        [HttpPost]
        public IActionResult Swagger()
        {
            return RedirectToAction("/Home/Swagger/index.html");
        }

        public IActionResult Book()
        {
            return View();
        }

        [HttpPost]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            if(login == null || password == null)
            {
                return Ok();
            }
            _jWTService.Login(login, password);
            if (_jWTService.jwt == null)
            {
                return Ok();
            }
            return Ok(_homeService.GetAllTables());
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View("Views/Home/Registration.cshtml");
        }

        [HttpPost]
        public IActionResult Registration(string firstName, string secondName, int age, string login, string password)
        {
            if (firstName == null && secondName == null && age == 0 && login == null && password == null)
            {
                return Ok("Data not correct!");
            }
            if (age <= 0 || age >= 99)
            {
                return Ok("Age not correct!");
            }
            Person person = new Person { Age = age, Login = login, Password = password, FirstName = firstName, SecondName = secondName, Role = "user" }; 
            _homeService.CreatePerson(person);
            return Ok();
        }

        [HttpPost]
        public IActionResult RefreshTable([FromForm]TypeTable typeTable)
        {
            ViewBag.TypeTable = typeTable.ToString();
            return PartialView("PartialView/_Tables", _homeService.GetAllTables());
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(CreateBookViewModel createBookViewModel)
        {
            var data =  await _homeService.CreateBookCategoryAvtorTables(createBookViewModel);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult SaveComment(string Comment)
        {
            //Comment not worked
            //_homeService.CreateAndGetAllComments(_userName, Comment);
            return PartialView("PartialView/_Comment", _homeService.GetAllTables());
        }

        [HttpPost]
        public IActionResult NavigationToIndex()
        {
            return Ok();
        }
    }
}