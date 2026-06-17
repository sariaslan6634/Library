using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Books.Commands.UpdateBookCommand
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Writer).NotEmpty().MaximumLength(50);
            RuleFor(x => x.PageNumber).GreaterThan(0);
        }
    }
}
