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
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<CreateUserViewModel, Person>()
                .ForMember(destination => destination.Login, source => source.MapFrom(src => src.Email))
                .ForMember(destination => destination.Password, source => source.MapFrom(src => src.Password))
                .ForMember(destination => destination.FirstName, source => source.MapFrom(src => src.UserName));

            CreateMap<UpdatePersonViewModel, Person>();
            CreateMap<Person, PersonByIdViewModel>();

            CreateMap<Person, AllPersonViewModelItem>();
        }
    }
}
