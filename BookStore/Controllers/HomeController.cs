using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using BookStore.Common.ViewModels;
using BookStore.Common.ViewModels.HomeController.Post;
using BookStore.DAL.Models;
using BookStore.DAL.Enums;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly IJWTService _jWTService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(IJWTService jWTService, IHomeService homeService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _homeService = homeService;
            _jWTService = jWTService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Login(string login, string password)
        //{
        //    if (login == null || password == null)
        //    {
        //        return Ok();
        //    }
        //    _jWTService.Login(login, password);
        //    if (_jWTService.jwt == null)
        //    {
        //        return Ok();
        //    }
        //    return Ok(_homeService.GetAllTables());
        //}

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var claims = new[]
                        {
                            new Claim("name", model.Email)
                        };

                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return Ok();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View("Views/Home/Registration.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegisterViewModel model)
        {
            if (model.Email == null || model.Password == null || model.PasswordConfirm == null)
            {
                return View("Views/Home/Registration.cshtml");
            }
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { Email = model.Email, UserName = model.Email };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        //[HttpPost]
        //public IActionResult Registration(LoginViewModel model)
        //{
        //    if (model == null)
        //    {
        //        return Ok("Data not correct!");
        //    }
        //    //if (age <= 0 || age >= 99)
        //    //{
        //    //    return Ok("Age not correct!");
        //    //}
        //    //Person person = new Person { Age = age, Login = login, Password = password, FirstName = firstName, SecondName = secondName, Role = "user" };
        //    //_homeService.CreatePerson(person);
        //    return Ok();
        //}

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