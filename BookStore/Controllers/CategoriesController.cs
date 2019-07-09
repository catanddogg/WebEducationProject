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
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //GET : api/categories
        [HttpGet]
        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryService.GetAllCategory();
        }

        //GET : api/categories/{id}
        [HttpGet("{id}")]
        public Category GetActegoryById(int id)
        {
            return _categoryService.GetCategoryById(id);
        }

        //POST : api/categories
        [HttpPost]
        public void CreateCategory(Category category)
        {
            _categoryService.CreateCategory(category);
        }

        //PUT : api/categories
        [HttpPut]
        public void UpdateCategory(Category category)
        {
            _categoryService.UpdateCategory(category);
        }

        //Delete : api/categories/{id}
        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
        }

        // GET /api/books/category/
        [HttpGet("category/{category}")]
        public IEnumerable<Category> GetCategoriesBooks(int category)
        {
            IEnumerable<Category> bookItem = _categoryService.GetCategoryBooks(category);
            return bookItem;
        }

        // GET /api/books/avtorandcategory/
        [HttpGet("avtorandcategory/{avtor}/{category}")]
        public IEnumerable<Category> GetAvtorandCategoryBooks(int category, string avtor)
        {
            IEnumerable<Category> bookItem = _categoryService.GetAutorAndCategoryBook(avtor, category);
            return bookItem;
        }
    }
}