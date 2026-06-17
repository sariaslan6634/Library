using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class Member
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<BorrowRecord> BorrowRecords { get; set; }
    }
}
