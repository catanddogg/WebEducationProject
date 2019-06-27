using System;
using BookStore.DAL.Enums;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using BookStore.Services.JWT;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private static bool _firstComeRegistaretion = true;
        private static bool _registrationBack;

        private readonly IPersonService _personService;
        private readonly IBookService _bookService;
        private readonly IAvtorService _avtorService;
        private readonly ICategoryService _categoryService;

        public HomeController(BooksContext context, IPersonService personService, IBookService bookService, IAvtorService avtorService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _avtorService = avtorService;
            _bookService = bookService;
            _personService = personService;
        }

        public IActionResult Index()
        {
            if (JWTManager.jwt == null || JWTManager.jwt.ValidTo < DateTime.UtcNow)
            {
                return View("Views/Home/Login.cshtml");
            }
            return View(_bookService.GetAllTables());
        }
     
        [HttpPost]
        public IActionResult Index(TypeTable typeTable)
        {
            if (JWTManager.jwt == null || JWTManager.jwt.ValidTo < DateTime.UtcNow)
            {
                return View("Views/Home/Login.cshtml");
            }
            ViewBag.TypeTable = typeTable.ToString();
            return View(_bookService.GetAllTables());
        }

        [HttpPost]
        public IActionResult Swagger()
        {
            return new RedirectResult("/Home/Swagger/index.html");
        }

        [HttpPost]
        public IActionResult About()
        {
            if (JWTManager.jwt == null || JWTManager.jwt.ValidTo < DateTime.UtcNow)
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
            Person person = _personService.GetPersonByLoginAndPassword(login, password);
            if (login == null || password == null || person == null)
            {
                TempData["noticeLogin"] = "Invalid username or password.";
                return View();
            }
            JWTAndRefreshToken jWTAndRefreshToken = JWTManager.Login(login, password);
            if (JWTManager.jwt == null)
            {
                TempData["noticeLogin"] = "Invalid username or password.";
                return View();
            }
            person.RefreshToken = jWTAndRefreshToken.RefreshToken;
            _personService.UpdatePerson(person);
            return View("Views/Home/Index.cshtml");
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
            _personService.CreatePerson(person);
            return View("Views/Home/Login.cshtml");
        }


        [HttpPost]
        public ActionResult RefreshTable([FromForm]TypeTable typeTable)
        {
            ViewBag.TypeTable = typeTable.ToString();
            return PartialView("Index", _bookService.GetAllTables());
            //return new JsonResult(typeTable);
        }   
    }
}