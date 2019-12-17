using BookStore.Common.ViewModels;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Models;
using BookStore.DAL.Enums;
using BookStore.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public class HomeService : IHomeService
    {
        private readonly IAuthorRepository _avtorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ICommentRepository _commentRepository;

        public HomeService(IAuthorRepository avtorRepository, IBookRepository bookRepository, ICategoryRepository categoryRepository,
            IPersonRepository personRepository, ICommentRepository commentRepository)
        {
            _avtorRepository = avtorRepository;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _personRepository = personRepository;
            _commentRepository = commentRepository;
        }

        public async Task CreateAndGetAllCommentsAsync(string UserName, string Comment)
        {
            await _commentRepository.CreateAndGetAllCommentsAsync(UserName, Comment);
        }

        public async Task<string> CreateBookCategoryAvtorTablesAsync(CreateBookViewModel createBookViewModel)
        {
            if (createBookViewModel.Name != null && createBookViewModel.file != null && createBookViewModel.Publisher != null &&
                createBookViewModel.Genre1 != CategoryType.None && createBookViewModel.Genre2 != CategoryType.None && createBookViewModel.Avtor != null)
            {
                if (createBookViewModel.file.Length > 0)
                {
                    string fileName = Path.GetFileName(createBookViewModel.file.FileName);
                    var FileExtension = Path.GetExtension(fileName);
                    string newFileName = Guid.NewGuid().ToString() + FileExtension;
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\uploadimage\\", newFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                         await createBookViewModel.file.CopyToAsync(stream);
                    }

                    Book book = new Book() { Name = createBookViewModel.Name, Path = newFileName };

                    await _bookRepository.InsertAsync(book);

                    Author author = new Author() { NameAuthor = createBookViewModel.Avtor, Publisher = createBookViewModel.Publisher};

                    await _avtorRepository.InsertAsync(author);

                    //Category category = new Category() { CategoryType = createBookViewModel.Genre1};

                    //await _categoryRepository.Create(category);

                    //Category category1 = new Category() { CategoryType = createBookViewModel.Genre2};

                    //await _categoryRepository.Create(category1);
                }
                return "Index";
            }
            return "Data not correct!";
        }

        public async Task CreatePersonAsync(Person person)
        {
            await _personRepository.InsertAsync(person);
        }

        public async Task<Person> GetPersonByLoginAndPasswordAsync(string login, string password)
        {
            Person result = await _personRepository.GetPersonByLoginAndPasswordAsync(login, password);

            return result;
        }              
    }
}
