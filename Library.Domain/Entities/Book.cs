using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PageNumber { get; set; }
        public string Writer { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
    }
}
