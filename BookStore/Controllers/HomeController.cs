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
        private static bool _firstComeRegistaretion = true;
        private static bool _registrationBack;
        private static string _userName;

        private readonly IHomeService _homeService;
        private readonly IJWTService _jWTService;

        public HomeController(IJWTService jWTService, IHomeService homeService)
        {
            _homeService = homeService;
            _jWTService = jWTService;
        }

        public IActionResult Index()
        {
            if (_jWTService.jwt == null || _jWTService.jwt.ValidTo < DateTime.UtcNow)
            {
                return View("Views/Home/Login.cshtml");
            }
            return View(_homeService.GetAllTables());
        }
     
        [HttpPost]
        public IActionResult Index([FromForm]TypeTable typeTable)
        {
            if (_jWTService.jwt == null || _jWTService.jwt.ValidTo < DateTime.UtcNow)
            {
                return View("Views/Home/Login.cshtml");
            }
            ViewBag.TypeTable = typeTable.ToString();
            return PartialView("Views/Home/Index.cshtml", _homeService.GetAllTables());
        }

        [HttpPost]
        public IActionResult Swagger()
        {
            return new RedirectResult("/Home/Swagger/index.html");
        }

        public IActionResult Book()
        {
            return View();
        }

        [HttpPost]
        public IActionResult About()
        {
            if (_jWTService.jwt == null || _jWTService.jwt.ValidTo < DateTime.UtcNow)
            {
                return View("Views/Home/Login.cshtml");
            }
            return View();
        }

        public IActionResult Login()
        {
            _registrationBack = false;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            if(_registrationBack)
            {
                _registrationBack = false;
                return View();
            }
            JWTAndRefreshToken jWTAndRefreshToken = _jWTService.Login(login, password);
            if (_jWTService.jwt == null)
            {
                return View();
            }
            //_userName = person.FirstName;
            return View("Views/Home/Index.cshtml", _homeService.GetAllTables());
        }
        

        [HttpPost]
        public IActionResult Registration(string firstName, string secondName, int age, string login, string password)
        {
            TempData["noticeRegistration"] = "";
            _registrationBack = true;
            if (_firstComeRegistaretion)
            {
                _firstComeRegistaretion = false;
                return View();
            }
            if (firstName == null && secondName == null && age == 0 && login == null && password == null)
            {
                TempData["noticeRegistration"] = "Enter all fields!";
                return View();
            }
            if (firstName == null)
            {
                TempData["noticeRegistration"] = "Enter Firest Name!";
                return View();
            }
            if (secondName == null)
            {
                TempData["noticeRegistration"] = "Enter Second Name!";
                return View();
            }
            if (age < 0 || age >= 99)
            {
                TempData["noticeRegistration"] = "Age is not correct!";
                return View();
            }
            if (login == null)
            {
                TempData["noticeRegistration"] = "Enter login!";
                return View();
            }
            if (password == null)
            {
                TempData["noticeRegistration"] = "Enter password!";
                return View();
            }

            Person person = new Person { Age = age, Login = login, Password = password, FirstName = firstName, SecondName = secondName, Role = "user" }; 
            _homeService.CreatePerson(person);
            return View("Views/Home/Login.cshtml");
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
            await _homeService.CreateBookCategoryAvtorTables(createBookViewModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveComment(string Comment)
        {
            _homeService.CreateAndGetAllComments(_userName, Comment);
            return PartialView("PartialView/_Comment", _homeService.GetAllTables());
        }
    }
}