using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Exceptions.CustomExceptions
{
    public class NotFoundException : Exception
    {        
        public NotFoundException(string message) : base(message) { }
    }
}
