using AutoMapper;
using BookStore.Common.ViewModels.BaseViewModel;
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
        private readonly IJWTService _jWTService;
        #endregion Properties & Variables

        #region Constructors
        public PersonService(IPersonRepository personRepository,
                             IMapper mapper,
                             IJWTService jWTService)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _jWTService = jWTService;
        }
        #endregion Constructors

        #region Public Methods
        public async Task<BaseRequestViewModel> CreatePerson(CreateUserViewModel createPersonViewModel)
        {
            var result = new BaseRequestViewModel();

            if(createPersonViewModel.Password !=  createPersonViewModel.ConfirmPassword)
            {
                result.Message = "Not the same password and confirm password";
                result.Success = false;

                return result;
            }

            bool isRegistered = await _personRepository.CheckReduplicationUserName(createPersonViewModel.UserName);

            if(isRegistered)
            {
                result.Message = "This is username was busy";
                result.Success = false;

                return result;
            }

            bool isEmailRegistered = await _personRepository.CheckReduplicationEmail(createPersonViewModel.Email);

            if(isEmailRegistered)
            {
                result.Message = "This is email was busy";
                result.Success = false;

                return result;
            }

            Person person = _mapper.Map<Person>(createPersonViewModel);

            await _personRepository.Create(person);

            result.Success = true;
            result.Message = "User successfully created";

            return result;
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

        public async Task<LoginRequestViewModel> GetPersonByLoginAndPassword(string login, string password)
        {
            var result = new LoginRequestViewModel();

            if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                result.Message = "Incorrect login or password";
                result.Success = false;

                return result;
            }
            Person person = await _personRepository.GetPersonByLoginAndPassword(login, password);

            if(person ==  null)
            {
                result.Message = "User not registered with this login";
                result.Success = false;

                return result;
            }

            JWTAndRefreshToken jWTAndRefreshToken = await _jWTService.Login(person.Login, person.Password);

            result.AccessToken = jWTAndRefreshToken.AccessToken;
            result.RefreshToken = jWTAndRefreshToken.RefreshToken;
            result.Success = true;
            result.Message = string.Empty;

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
