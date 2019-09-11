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
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public class PersonService : IPersonService
    {
        #region Properties & Variables
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        #endregion Properties & Variables

        #region Constructors
        public PersonService(IPersonRepository personRepository,
                             IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        #endregion Constructors

        #region Public Methods
        public void CreatePerson(CreatePersonViewModel createPersonViewModel)
        {
            Person person = _mapper.Map<Person>(createPersonViewModel);

            _personRepository.Create(person);
        }

        public void DeletePerson(int id)
        {
            _personRepository.Delete(id);
        }

        public async Task<AllPersonViewModel> GetAllPerson()
        {
            var result = new AllPersonViewModel();

            List<Person>  people = await _personRepository.GetAll();

            List<AllPersonViewModelItem> allPersonViewModel = _mapper.Map<List<AllPersonViewModelItem>>(people);

            result.Persons = allPersonViewModel;

            return result;
        }

        public PersonByIdViewModel GetPersonById(int id)
        {
            Person person = _personRepository.GetById(id);

            PersonByIdViewModel personByIdViewModel = _mapper.Map<PersonByIdViewModel>(person);

            return personByIdViewModel;
        }

        public async Task<Person> GetPersonByLoginAndPassword(string login, string password)
        {
            Person result = await _personRepository.GetPersonByLoginAndPassword(login, password);

            return result;
        }

        public async Task<Person> GetPersonByRefreshToken(string refreshToken)
        {
            Person result = await _personRepository.GetPersonByRefreshToken(refreshToken);

            return result;
        }

        public void UpdatePerson(UpdatePersonViewModel updatePersonViewModel)
        {
            Person person = _mapper.Map<Person>(updatePersonViewModel);

            _personRepository.Update(person);
        }
        #endregion Public Methods
    }
}
