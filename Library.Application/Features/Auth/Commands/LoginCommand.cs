using Library.Application.Common.Interfaces;
using Library.Application.Exceptions.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Auth.Commands
{
    public record LoginCommand(
        string Email,
        string Password
        ) : IRequest<string>;
    public class LoginCommandHandler(ILibraryDbContext _context, ITokenService _token) : IRequestHandler<LoginCommand, string>
    {
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
            if (user is null)
                throw new NotFoundException("Kullanıcı Bulunamadı.");

            if (!BCrypt.Net.BCrypt.Verify(request.Password,user.PasswordHash))
                throw new UnauthorizedException("Email veya şifre hatalı");

            var token = _token.GenerateToken(user.Id, user.Email, new List<string>());
            return token;

        }
    }
}
