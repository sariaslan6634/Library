using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Exceptions.CustomExceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message){ }
    }
}
