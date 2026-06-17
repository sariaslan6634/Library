using AutoMapper;
using Library.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Library.Application.Features.Books.Queries.GetBooksListQuery;

namespace Library.Application.Features.Books.Queries
{
    public record GetBooksListQuery : IRequest<List<GetBooksListQueryDto>>
    {
        public record GetBooksListQueryDto(
            Guid Id,
            string Title,
            string Description,
            int PageNumber,
            string Writer,
            string MemberName,
            bool IsAvailable = true);
    }

    public class GetBooksListQueryHandler(ILibraryDbContext _context, IMapper _mapper) : IRequestHandler<GetBooksListQuery, List<GetBooksListQueryDto>>
    {
        public async Task<List<GetBooksListQueryDto>> Handle(GetBooksListQuery request, CancellationToken cancellationToken)
        {
            var books = await _context.Books
                .AsNoTracking()
                .Include(x=>x.BorrowRecords)
                .ThenInclude(x=>x.Member)
                .ToListAsync(cancellationToken);
            var dtoResult = _mapper.Map<List<GetBooksListQueryDto>>(books);
            return dtoResult;
        }
    }
}
