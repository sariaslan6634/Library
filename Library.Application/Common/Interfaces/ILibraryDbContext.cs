using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Common.Interfaces
{
    public interface ILibraryDbContext
    {
        DbSet<Book> Books { get; }
        DbSet<Member> Members { get; }
        DbSet<BorrowRecord> BorrowRecords { get; }
        DbSet<User> Users { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
