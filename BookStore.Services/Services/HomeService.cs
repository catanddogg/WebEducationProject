using BookStore.Common.ViewModels;
using BookStore.DAL.Enums;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public class HomeService : IHomeService
    {
        private readonly IAvtorRepository _avtorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ICommentRepository _commentRepository;

        public HomeService(IAvtorRepository avtorRepository, IBookRepository bookRepository, ICategoryRepository categoryRepository,
            IPersonRepository personRepository, ICommentRepository commentRepository)
        {
            _avtorRepository = avtorRepository;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _personRepository = personRepository;
            _commentRepository = commentRepository;
        }

        public void CreateAndGetAllComments(string UserName, string Comment)
        {
            _commentRepository.CreateAndGetAllComments(UserName, Comment);
        }

        public async Task CreateBookCategoryAvtorTables(CreateBookViewModel createBookViewModel)
        {
            if (createBookViewModel.Name != null && createBookViewModel.Path != null && createBookViewModel.Publisher != null &&
                createBookViewModel.Genre1 != CategoryType.None && createBookViewModel.Genre2 != CategoryType.None && createBookViewModel.Avtor != null)
            {
                if (createBookViewModel.Path.Length > 0)
                {
                    string fileName = Path.GetFileName(createBookViewModel.Path.FileName);
                    var FileExtension = Path.GetExtension(fileName);
                    string newFileName = Guid.NewGuid().ToString() + FileExtension;
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\uploadimage\\", newFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                          await createBookViewModel.Path.CopyToAsync(stream);
                    }
                    Book book = new Book() { Name = createBookViewModel.Name, Path = newFileName };
                    _bookRepository.CreateBook(book);

                    Avtor avtor = new Avtor() { NameAvtor = createBookViewModel.Avtor, Publisher = createBookViewModel.Publisher, Book = book };
                    _avtorRepository.CreateAvtor(avtor);

                    Category category = new Category() { CategoryType = createBookViewModel.Genre1, Book = book };
                    _categoryRepository.CreateCategory(category);

                    Category category1 = new Category() { CategoryType = createBookViewModel.Genre2, Book = book };
                    _categoryRepository.CreateCategory(category1);
                }
                //return true;
            }
            //return false;
        }

        public void CreatePerson(Person person)
        {
            _personRepository.CreatePerson(person);
        }

        public CategoriesBooksAvtors GetAllTables()
        {
            return _bookRepository.GetAllTables();
        }

        public Person GetPersonByLoginAndPassword(string login, string password)
        {
            return _personRepository.GetPersonByLoginAndPassword(login, password);
        }

        public void UpdatePerson(Person person)
        {
            _personRepository.UpdatePerson(person);
        }
    }
}
