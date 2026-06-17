using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class BorrowRecord
    {
        public Guid Id { get; set; }
        public DateTime BorrowedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Guid MemberId { get; set; }
        public Member Member { get; set; }
    }
}
