using BookStore.Common.ViewModels;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IHomeService
    {
        void CreatePerson(Person person);
        CategoriesBooksAuthorsDTO GetAllTables();
        void CreateAndGetAllComments(string UserName, string Comment);
        Task<string> CreateBookCategoryAvtorTables(CreateBookViewModel createBookViewModel);
        Person GetPersonByLoginAndPassword(string login, string password);
    }
}
