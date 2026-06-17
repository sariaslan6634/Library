using AutoMapper;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Books.Commands.CreateBook
{
    public record CreateBookCommand(string Title,
     string Description,
     int PageNumber,
     string Writer,
     bool IsAvailable = true) : IRequest<Guid>;

    public class CreateBookCommandHandler(ILibraryDbContext _contex, IMapper _mapper) : IRequestHandler<CreateBookCommand, Guid>
    {
        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            _contex.Books.Add(book);
            await _contex.SaveChangesAsync(cancellationToken);
            return book.Id;
        }
    }
}
