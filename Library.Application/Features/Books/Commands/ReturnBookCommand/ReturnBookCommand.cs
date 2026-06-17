using Library.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Books.Commands.ReturnBookCommand
{
    public record ReturnBookCommand(Guid BookId) : IRequest;
    public class ReturnBookCommandHandler(ILibraryDbContext _context) : IRequestHandler<ReturnBookCommand>
    {
        public async Task Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            var borrowRecord = await _context.BorrowRecords.Where(x => x.BookId == request.BookId && x.ReturnedAt == null).FirstOrDefaultAsync(cancellationToken);
            if (borrowRecord is null) 
                throw new Exception("Aktif ödünç kaydı bulunamadı.");

            borrowRecord.ReturnedAt = DateTime.UtcNow;

            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == request.BookId, cancellationToken);

            book!.IsAvailable = true;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
