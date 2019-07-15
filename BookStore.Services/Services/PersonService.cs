using AutoMapper;
using BookStore.Common.ViewModels.PersonController.Get;
using BookStore.Common.ViewModels.PersonController.Post;
using BookStore.Common.ViewModels.PersonController.Put;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.DAL.Repositories.EntityFramework;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BookStore.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void CreatePerson(CreatePersonViewModel createPersonViewModel)
        {
            Person person = Mapper.Map<CreatePersonViewModel, Person>(createPersonViewModel);
            _personRepository.Create(person);
        }

        public void DeletePerson(int id)
        {
            _personRepository.Delete(id);
        }

        public AllPersonViewModel GetAllPerson()
        {
            IEnumerable<Person>  people = _personRepository.GetAll();
            AllPersonViewModel allPersonViewModel = Mapper.Map<IEnumerable<Person>, AllPersonViewModel>(people);
            return allPersonViewModel;
        }

        public PersonByIdViewModel GetPersonById(int id)
        {
            Person person = _personRepository.GetById(id);
            PersonByIdViewModel personByIdViewModel = Mapper.Map<Person, PersonByIdViewModel>(person);
            return personByIdViewModel;
        }

        public Person GetPersonByLoginAndPassword(string login, string password)
        {
            return _personRepository.GetPersonByLoginAndPassword(login, password);
        }

        public Person GetPersonByRefreshToken(string refreshToken)
        {
            return _personRepository.GetPersonByRefreshToken(refreshToken);
        }

        public void UpdatePerson(UpdatePersonViewModel updatePersonViewModel)
        {
            Person person = Mapper.Map<UpdatePersonViewModel, Person>(updatePersonViewModel);
            _personRepository.Update(person);
        }
    }
}
