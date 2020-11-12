using AutoMapper;
using BookStore.Common.ViewModels.BaseViewModel;
using BookStore.Common.ViewModels.PersonController.Get;
using BookStore.Common.ViewModels.PersonController.Post;
using BookStore.Common.ViewModels.PersonController.Put;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public class PersonService : IPersonService
    {
        #region Properties & Variables
        private readonly IPersonRepository _personRepository;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        private readonly IJWTService _jWTService;
        #endregion Properties & Variables

        #region Constructors
        public PersonService(IPersonRepository personRepository,
                             IMapper mapper,
                             IJWTService jWTService,
                             IMailService mailService)
        {
            _personRepository = personRepository;
            _jWTService = jWTService;
            _mailService = mailService;

            _mapper = mapper;
        }
        #endregion Constructors

        #region Public Methods
        public async Task<BaseRequestViewModel> CreatePersonAsync(CreateUserViewModel createPersonViewModel)
        {
            var result = new BaseRequestViewModel();

            if(createPersonViewModel.Password !=  createPersonViewModel.ConfirmPassword)
            {
                result.Message = "Not the same password and confirm password";
                result.Success = false;

                return result;
            }

            bool isRegistered = await _personRepository.CheckReduplicationUserNameAsync(createPersonViewModel.UserName);

            if(isRegistered)
            {
                result.Message = "This is username was busy";
                result.Success = false;

                return result;
            }

            bool isEmailRegistered = await _personRepository.CheckReduplicationEmailAsync(createPersonViewModel.Email);

            if(isEmailRegistered)
            {
                result.Message = "This is email was busy";
                result.Success = false;

                return result;
            }

            User person = _mapper.Map<User>(createPersonViewModel);

            await _personRepository.InsertAsync(person);

            result.Success = true;
            result.Message = "User successfully created";

            return result;
        }

        public async Task DeletePersonAsync(int id)
        {
            await _personRepository.DeleteAsync(id);
        }

        public async Task<AllPersonViewModel> GetAllPersonAsync()
        {
            var result = new AllPersonViewModel();

            List<User>  people = await _personRepository.GetAllAsync();

            result.Persons = _mapper.Map<List<AllPersonViewModelItem>>(people);

            return result;
        }

        public async Task<PersonByIdViewModel> GetPersonByIdAsync(int id)
        {
            User person = await _personRepository.GetByIdAsync(id);

            PersonByIdViewModel personByIdViewModel = _mapper.Map<PersonByIdViewModel>(person);

            return personByIdViewModel;
        }

        public async Task<LoginRequestViewModel> GetPersonByLoginAndPasswordAsync(string login, string password)
        {
            var result = new LoginRequestViewModel();

            if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                result.Message = "Incorrect login or password";
                result.Success = false;

                return result;
            }

            User person = await _personRepository.GetPersonByLoginAndPasswordAsync(login, password);

            if(person ==  null)
            {
                result.Message = "User not registered with this login";
                result.Success = false;

                return result;
            }

            JWTAndRefreshToken jWTAndRefreshToken = await _jWTService.LoginAsync(person.Login, person.Password);

            result.AccessToken = jWTAndRefreshToken.AccessToken;
            result.RefreshToken = jWTAndRefreshToken.RefreshToken;
            result.UserName = person.FirstName;
            result.UserId = person.Id.ToString();
            result.Success = true;
            result.Message = string.Empty;

            return result;
        }

        public async Task<LoginRequestViewModel> GetPersonByRefreshTokenAsync(string refreshToken)
        {
            var result = new LoginRequestViewModel();

            User person = await _personRepository.GetPersonByRefreshTokenAsync(refreshToken);

            if(person == null)
            {
                result.Success = false;
                result.Message = "We do not have person with this refresh token.";

                return result;
            }

            JWTAndRefreshToken jWTAndRefreshToken = await _jWTService.LoginAsync(person.Login, person.Password);

            result.Success = true;
            result.AccessToken = jWTAndRefreshToken.AccessToken;
            result.RefreshToken = jWTAndRefreshToken.RefreshToken;

            return result;
        }

        public async Task UpdatePersonAsync(UpdatePersonViewModel updatePersonViewModel)
        {
            User person = _mapper.Map<User>(updatePersonViewModel);

            await _personRepository.UpdateAsync(person);
        }

        public async Task<BaseRequestViewModel> SendEmailToRecoverPasswordAsync(SendEmailToRecoverPasswordViewModel model)
        {
            var result = new BaseRequestViewModel();

            User person = await _personRepository.GetPersonByEmailAsync(model.PersonEmail);

            if(person == null)
            {
                result.Message = "There is not have person with this email";
                result.Success = false;

                return result;
            }

            string message = $"Follow this link to recover your password http://localhost:4200/ResetPassword/:id{person.ResetPasswordToken}";

            await _mailService.SendEmailAsync(model.PersonEmail, "Recovery password", message);

            result.Success = true;

            return result;
        }

        public async Task<BaseRequestViewModel> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            var result = new BaseRequestViewModel();

            if(model.Password != model.ConfirmPassword)
            {
                result.Message = "Not the same password and confirm password";
                result.Success = false;

                return result;
            }

            if(Guid.Parse(model.ResetPasswordToken) == default(Guid))
            {
                result.Message = "Something went wrong, try again please.";
                result.Success = false;

                return result;
            }

            bool success = await _personRepository.ResetPasswordAsync(model.Password, model.ResetPasswordToken);

            if(!success)
            {
                result.Message = "It is not longer possible to reset the password from this link";
                result.Success = false;

                return result;
            }

            result.Message = "Password changed successfully";
            result.Success = true;

            return result;
        }
        #endregion Public Methods
    }
}
