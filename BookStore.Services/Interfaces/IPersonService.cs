using BookStore.Common.ViewModels.PersonController.Get;
using BookStore.Common.ViewModels.PersonController.Post;
using BookStore.Common.ViewModels.PersonController.Put;
using BookStore.DAL.Models;
using BookStore.DAL.Repositories.EntityFramework;
using BookStore.Services.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BookStore.Services.Interfaces
{
    public interface IPersonService
    {
        AllPersonViewModel GetAllPerson();
        void CreatePerson(CreatePersonViewModel createPersonViewModel);
        void UpdatePerson(UpdatePersonViewModel updatePersonViewModel);
        void DeletePerson(int id);
        PersonByIdViewModel GetPersonById(int id);

        Person GetPersonByLoginAndPassword(string login, string password);
        Person GetPersonByRefreshToken(string refreshToken);
    }
}
