using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Common.ViewModels.CategoriesController.Get;
using BookStore.Common.ViewModels.CategoriesController.Post;
using BookStore.Common.ViewModels.CategoriesController.Put;
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
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //GET : api/categories
        [HttpGet]
        public AllCategoryViewModel GetAllCategories()
        {
            return _categoryService.GetAllCategory();
        }

        //GET : api/categories/{id}
        [HttpGet("{id}")]
        public CategoryByIdViewModel GetCategoryById(int id)
        {
            return _categoryService.GetCategoryById(id);
        }

        //POST : api/categories
        [HttpPost]
        public void CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {
            _categoryService.CreateCategory(createCategoryViewModel);
        }

        //PUT : api/categories
        [HttpPut]
        public void UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel)
        {
            _categoryService.UpdateCategory(updateCategoryViewModel);
        }

        //Delete : api/categories/{id}
        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
        }

        // GET /api/books/category/
        [HttpGet("category/{category}")]
        public CategoryBooksViewModel GetCategoriesBooks(int category)
        {
            CategoryBooksViewModel bookItem = _categoryService.GetCategoryBooks(category);
            return bookItem;
        }

        // GET /api/books/avtorandcategory/
        [HttpGet("avtorandcategory/{avtor}/{category}")]
        public AutorAndCategoryViewModel GetAvtorandCategoryBooks(int category, string avtor)
        {
            AutorAndCategoryViewModel bookItem = _categoryService.GetAutorAndCategoryBook(avtor, category);
            return bookItem;
        }
    }
}