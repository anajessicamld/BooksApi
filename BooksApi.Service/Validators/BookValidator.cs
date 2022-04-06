using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BooksApi.Domain.Entities;


namespace BooksApi.Service.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(c => c.Author)
                .NotEmpty().WithMessage("Please enter the Author.")
                .NotNull().WithMessage("Please enter the Author.");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter the Description.")
                .NotNull().WithMessage("Please enter the Description.");

            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Please enter the Title.")
                .NotNull().WithMessage("Please enter the Title.");
        }
    }
}
