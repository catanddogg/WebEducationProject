using AutoMapper;
using BookStore.Common.ViewModels.PersonController.Get;
using BookStore.Common.ViewModels.PersonController.Post;
using BookStore.Common.ViewModels.PersonController.Put;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Mapping
{
    public class PersonControllerProfile : Profile
    {
        public PersonControllerProfile()
        {
            CreateMap<CreatePersonViewModel, Person>();
            CreateMap<UpdatePersonViewModel, Person>();
            CreateMap<Person, PersonByIdViewModel>();
            CreateMap<IEnumerable<Person>, AllPersonViewModel>();
        }
    }
}
