using AutoMapper;
using Library.Application.Common.Interfaces;
using Library.Application.Exceptions.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Library.Application.Features.Books.Commands.UpdateBookCommand
{
    public record UpdateBookCommand(
        [property: JsonIgnore] Guid BookId,
        string Title,
        string Description,
        int PageNumber,
        string Writer,
        bool IsAvailable = true) : IRequest<Guid>;
    public class UpdateBookCommandHandler(ILibraryDbContext _context, IMapper _mapper) : IRequestHandler<UpdateBookCommand, Guid>
    {
        public async Task<Guid> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == request.BookId, cancellationToken);
            if (book is null)
                throw new NotFoundException("Kitap bulunamadı.");
            
            _mapper.Map(request, book);
            await _context.SaveChangesAsync(cancellationToken);

            return book.Id;
        }
    }
}
