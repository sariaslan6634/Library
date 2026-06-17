using AutoMapper;
using AutoMapper.Execution;
using Library.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Member.Commands.CreateMember
{
    public record CreateMemberCommand(
        string FirstName,
        string LastName,
        string Email
        ) : IRequest<Guid>;
    public class CreateMemberCommandHandler(IMapper _mapper,ILibraryDbContext _context) : IRequestHandler<CreateMemberCommand, Guid>
    {
        public async Task<Guid> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = _mapper.Map<Domain.Entities.Member>(request);
            _context.Members.Add(member);
            await _context.SaveChangesAsync(cancellationToken);
            return member.Id;
        }
    }
}
