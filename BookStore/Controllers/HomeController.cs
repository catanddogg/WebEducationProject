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
            Person person = _homeService.GetPersonByLoginAndPassword(login, password);
            if (login == null || password == null || person == null)
            {
                return View();
            }
            JWTAndRefreshToken jWTAndRefreshToken = _jWTService.Login(login, password);
            if (_jWTService.jwt == null)
            {
                return View();
            }
            person.RefreshToken = jWTAndRefreshToken.RefreshToken;
            _homeService.UpdatePerson(person);
            _userName = person.FirstName;
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

            //if(isValid)
            //{
                return RedirectToAction("Index");
            //}
            //if (createBookViewModel.Name != null && createBookViewModel.Path != null && createBookViewModel.Publisher != null &&
            //    createBookViewModel.Genre1 != CategoryType.None && createBookViewModel.Genre2 != CategoryType.None && createBookViewModel.Avtor != null)
            //{
            //    if (createBookViewModel.Path.Length > 0)
            //    {
            //        var fileName = Path.GetFileName(createBookViewModel.Path.FileName);
            //        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\uploadimage\\", fileName);
            //        using (var stream = new FileStream(filePath, FileMode.Create))
            //        {
            //            await createBookViewModel.Path.CopyToAsync(stream);
            //        }
            //        Book book = new Book() { Name = createBookViewModel.Name, Path = fileName };
            //        _bookService.CreateBook(book);

            //        Avtor avtor = new Avtor() { NameAvtor = createBookViewModel.Avtor, Publisher = createBookViewModel.Publisher, Book = book};
            //        _avtorService.CreateAvtor(avtor);

            //        Category category = new Category() { CategoryType = createBookViewModel.Genre1, Book = book};
            //        _categoryService.CreateCategory(category);

            //        Category category1= new Category() { CategoryType = createBookViewModel.Genre2, Book = book};
            //        _categoryService.CreateCategory(category1);
            //    }
            //    return RedirectToAction("Index");
            //}
            return View("Book");
        }

        [HttpPost]
        public IActionResult SaveComment(string Comment)
        {
            _homeService.CreateAndGetAllComments(_userName, Comment);
            return PartialView("PartialView/_Comment", _homeService.GetAllTables());
        }
    }
}