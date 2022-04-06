using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BooksApi.Domain.Entities;
using BooksApi.Domain.Interfaces;


namespace BooksApi.Service.Services
{
    public class BaseService<Book> : IBaseService<Book> where Book : BaseBook
    {
        private readonly IBaseRepository<Book> _baseRepository;

        public BaseService(IBaseRepository<Book> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Book Add<TValidator>(Book book) where TValidator : AbstractValidator<Book>
        {
            Validate(book, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(book);
            return book;
        }

        public void Delete(int Id) => _baseRepository.Delete(Id);

        public IList<Book> Get() => _baseRepository.Select();

        public Book GetById(int Id) => _baseRepository.Select(Id);

        public Book Update<TValidator>(Book book) where TValidator : AbstractValidator<Book>
        {
            Validate(book, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(book);
            return book;
        }

        private static void Validate(Book book, AbstractValidator<Book> validator)
        {
            if (book == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(book);
        }
    }
}
