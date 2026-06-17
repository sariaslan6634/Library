using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Exceptions.CustomExceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message) : base(message) { }
    }
}
