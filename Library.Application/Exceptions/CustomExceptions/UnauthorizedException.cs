using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Exceptions.CustomExceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message): base(message) { }
    }
}
