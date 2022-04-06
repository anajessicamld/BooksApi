using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BooksApi.Domain.Entities;

namespace BooksApi.Domain.Interfaces
{
    public interface IBaseService<Book> where Book : BaseBook
    {
        Book Add<TValidator>(Book book) where TValidator : AbstractValidator<Book>;
        void Delete(int Id);
        IList<Book> Get();
        Book GetById(int Id);
        Book Update<TValidator>(Book book) where TValidator : AbstractValidator<Book>;
    }
}
