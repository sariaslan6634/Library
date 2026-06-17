using AutoMapper;
using Library.Application.Common.Interfaces;
using Library.Application.Exceptions.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Library.Application.Features.Books.Queries.GetBookByIdQuery;

namespace Library.Application.Features.Books.Queries
{
    public record GetBookByIdQuery(Guid BookId) : IRequest<CreateBookCommandDto>
    {
        public record CreateBookCommandDto(
            Guid Id,
            string Title,
            string Description,
            int PageNumber,
            string Writer,
            string? MemberName,
            bool IsAvailable);
    }

    public class GetBookByIdQueryHandler(ILibraryDbContext _context,IMapper _mapper) : IRequestHandler<GetBookByIdQuery, CreateBookCommandDto>

    {
        public async Task<CreateBookCommandDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.AsNoTracking().Include(x=>x.BorrowRecords).ThenInclude(x=>x.Member).FirstOrDefaultAsync(x => x.Id == request.BookId, cancellationToken);

            if (book is null)
                throw new NotFoundException("Kitap bulunamadı.");

            return _mapper.Map<CreateBookCommandDto>(book);
        }
    }
}
