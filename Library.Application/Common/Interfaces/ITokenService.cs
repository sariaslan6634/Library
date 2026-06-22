using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Guid Id,string email, List<string> roles);
    }
}
