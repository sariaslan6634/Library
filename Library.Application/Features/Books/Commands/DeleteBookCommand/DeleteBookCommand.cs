using Library.Application.Common.Interfaces;
using Library.Application.Exceptions.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Books.Commands.DeleteBookCommand
{
    public record DeleteBookCommand(Guid BookId) : IRequest;
    public class DeleteBookCommandHandler(ILibraryDbContext _context) : IRequestHandler<DeleteBookCommand>
    {
        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == request.BookId, cancellationToken);
            if (book is null)
                throw new NotFoundException("Kitap Bulunamadı.");
            if (book.IsAvailable == false)
                throw new BadRequestException("Kitap ödünç verildiği için silinemez.");

            _context.Books.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);            
        }
    }
}