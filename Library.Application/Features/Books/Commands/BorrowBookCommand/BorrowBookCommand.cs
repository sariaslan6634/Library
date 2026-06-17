using AutoMapper;
using Library.Application.Common.Interfaces;
using Library.Application.Exceptions.CustomExceptions;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Books.Commands.BorrowBookCommand
{
    public record BorrowBookCommand
        (Guid BookId,
        Guid MemberId) : IRequest<Guid>;
    public class BorrowBookCommandHandler(ILibraryDbContext _context) : IRequestHandler<BorrowBookCommand, Guid>
    {
        public async Task<Guid> Handle(BorrowBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == request.BookId, cancellationToken);
            if (book is null)
                throw new NotFoundException("Kitap Bulunamdı.");

            if(!book.IsAvailable)
                throw new BadRequestException("Kitap müsait değil.");

            var borrowRecord = new BorrowRecord
            {
                Id = Guid.NewGuid(),
                BookId = request.BookId,
                MemberId = request.MemberId,
                BorrowedAt = DateTime.UtcNow
            };

            book.IsAvailable = false;
            _context.BorrowRecords.Add(borrowRecord);
            await _context.SaveChangesAsync(cancellationToken);

            return borrowRecord.Id;
        }
    }
}
