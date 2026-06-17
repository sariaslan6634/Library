using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Writer).NotEmpty().MaximumLength(50);
            RuleFor(x => x.PageNumber).GreaterThan(0);
        }
    }
}
