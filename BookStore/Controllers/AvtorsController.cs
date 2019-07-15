using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Common.ViewModels.AvtorsController.Get;
using BookStore.Common.ViewModels.AvtorsController.Post;
using BookStore.Common.ViewModels.AvtorsController.Put;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AvtorsController : Controller
    {
        private readonly IAvtorService _avtorService;

        public AvtorsController(IAvtorService avtorService)
        {
            _avtorService = avtorService;
        }

        //GET : /api/avtors
        [HttpGet]
        public AllAvtorViewModel GetAllAvtors()
        {
            return _avtorService.GetAllAvtors();
        }

        //GET : api/avtors/{id}
        [AllowAnonymous]
        [HttpGet("{id}")]
        public AvtorByIdViewModel GetAvtorById(int id)
        {
            var test = _avtorService.GetAvtorById(id);
            return test;
        }

        // POST : api/avtors
        [HttpPost]
        public void CreateAvtor(CreateAvtorViewModel createAvtorViewModel)
        {
            _avtorService.CreateAvtor(createAvtorViewModel);
        }

        //PUT : api/avtors
        [HttpPut]
        public void UpdateAvtor(UpdateAvtorViewModel updateAvtorViewModel)
        {
            _avtorService.UpdateAvtor(updateAvtorViewModel);
        }

        //Delete : api/avtors
        [HttpDelete]
        public void DeleteAvtor(int id)
        {
            _avtorService.DeleteAvtor(id);
        }

        // GET /api/avtors/avtor/{avtor}
        [HttpGet("avtor/{avtor}")]
        public AvtorBooksViewModel GetAvtorBooks(string avtor)
        {
            AvtorBooksViewModel bookItem = _avtorService.GetAvtorBooks(avtor);
            return bookItem;
        }

        // GET /api/avtors/publisher/{publisher}
        [HttpGet("publisher/{publisher}")]
        public PublishersBooksViewModel GetPublishersBooks(string publisher)
        {
            PublishersBooksViewModel bookItem = _avtorService.GetPublisherBooks(publisher);
            return bookItem;
        }
    }
}