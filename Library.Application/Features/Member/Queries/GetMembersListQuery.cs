using AutoMapper;
using Library.Application.Common.Interfaces;
using Library.Application.Features.Books.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Library.Application.Features.Member.Queries.GetMembersListQuery;

namespace Library.Application.Features.Member.Queries
{
    public record GetMembersListQuery : IRequest<List<GetMembersListQueryDto>>
    {
        public record GetMembersListQueryDto
        (
             Guid Id ,
             string FirstName,
             string LastName,
             string Email
        );
    }
    public class GetMembersListQueryHandler(ILibraryDbContext _context, IMapper _mapper) : IRequestHandler<GetMembersListQuery, List<GetMembersListQueryDto>>
    {
        public async Task<List<GetMembersListQueryDto>> Handle(GetMembersListQuery request, CancellationToken cancellationToken)
        {
            var members = await _context.Members
                .AsNoTracking().ToListAsync(cancellationToken);
            var dtoResult = _mapper.Map<List<GetMembersListQueryDto>>(members);
            return dtoResult;
        }
    }
}
