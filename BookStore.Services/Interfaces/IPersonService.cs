﻿using BookStore.Common.ViewModels.PersonController.Get;
using BookStore.Common.ViewModels.PersonController.Post;
using BookStore.Common.ViewModels.PersonController.Put;
using BookStore.DAL.Models;
using BookStore.DAL.Repositories.EntityFramework;
using BookStore.Services.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IPersonService
    {
        Task<AllPersonViewModel> GetAllPerson();
        void CreatePerson(CreatePersonViewModel createPersonViewModel);
        void UpdatePerson(UpdatePersonViewModel updatePersonViewModel);
        void DeletePerson(int id);
        PersonByIdViewModel GetPersonById(int id);

        Task<Person> GetPersonByLoginAndPassword(string login, string password);
        Task<Person> GetPersonByRefreshToken(string refreshToken);
    }
}
