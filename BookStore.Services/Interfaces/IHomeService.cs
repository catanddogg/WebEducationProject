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
        void CreateAndGetAllComments(string UserName, string Comment);
        Task<string> CreateBookCategoryAvtorTables(CreateBookViewModel createBookViewModel);
        Task<Person> GetPersonByLoginAndPassword(string login, string password);
    }
}
