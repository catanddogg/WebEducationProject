using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class AvtorsController : Controller
    {
        private readonly IAvtorService _avtorService;
        public AvtorsController(IAvtorService avtorService)
        {
            _avtorService = avtorService;
        }

        //GET : /api/avtors
        [HttpGet]
        public IEnumerable<Avtor> GetAllAvtors()
        {
            return _avtorService.GetAllAvtors();
        }

        //GET : api/avtors/{id}
        [HttpGet("{id}")]
        public Avtor GetAvtorById(int id)
        {
            return _avtorService.GetAvtorById(id);
        }

        // POST : api/avtors
        [HttpPost]
        public void CreateAvtor([FromBody]Avtor avtor)
        {
            _avtorService.CreateAvtor(avtor);
        }

        //PUT : api/avtors
        [HttpPut]
        public void UpdateAvtor(Avtor avtor)
        {
            _avtorService.UpdateAvtor(avtor);
        }

        //Delete : api/avtors
        [HttpDelete]
        public void DeleteAvtor(int id)
        {
            _avtorService.DeleteAvtor(id);
        }

        // GET /api/avtors/avtor/{avtor}
        [HttpGet("avtor/{avtor}")]
        public IEnumerable<Avtor> Get(string avtor)
        {
            IEnumerable<Avtor> bookItem = _avtorService.GetAvtorBooks(avtor);
            return bookItem;
        }

        // GET /api/avtors/publisher/{publisher}
        [HttpGet("publisher/{publisher}")]
        public IEnumerable<Avtor> GetPublishersBooks(string publisher)
        {
            IEnumerable<Avtor> bookItem = _avtorService.GetPublisherBooks(publisher);
            return bookItem;
        }
    }
}