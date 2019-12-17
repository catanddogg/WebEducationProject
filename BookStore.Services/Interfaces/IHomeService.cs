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
        Task CreatePersonAsync(Person person);
        Task CreateAndGetAllCommentsAsync(string UserName, string Comment);
        Task<string> CreateBookCategoryAvtorTablesAsync(CreateBookViewModel createBookViewModel);
        Task<Person> GetPersonByLoginAndPasswordAsync(string login, string password);
    }
}
