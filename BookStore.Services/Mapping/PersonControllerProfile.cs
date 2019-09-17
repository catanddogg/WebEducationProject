using AutoMapper;
using BookStore.Common.ViewModels.PersonController.Get;
using BookStore.Common.ViewModels.PersonController.Post;
using BookStore.Common.ViewModels.PersonController.Put;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services.Mapping
{
    public class PersonControllerProfile : Profile
    {
        public PersonControllerProfile()
        {
            CreateMap<CreateUserViewModel, Person>();
            CreateMap<UpdatePersonViewModel, Person>();
            CreateMap<Person, PersonByIdViewModel>();

            CreateMap<Person, AllPersonViewModelItem>();
        }
    }
}
