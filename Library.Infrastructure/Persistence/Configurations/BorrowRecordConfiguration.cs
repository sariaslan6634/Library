using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Persistence.Configurations
{
    public class BorrowRecordConfiguration : IEntityTypeConfiguration<BorrowRecord>
    {
        public static readonly Guid memberId = Guid.Parse("a1b2c3d4-0000-0000-0000-000000000001");
        public static readonly Guid bookId = Guid.Parse("b1b2c3d4-0000-0000-0000-000000000001");
        public void Configure(EntityTypeBuilder<BorrowRecord> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(x => x.BorrowedAt).IsRequired();

            builder.Property(x => x.ReturnedAt).IsRequired(false);


            builder.HasOne(x => x.Book)
                .WithMany(x => x.BorrowRecords)
                .HasForeignKey(x => x.BookId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x=>x.Member)
                .WithMany(x=>x.BorrowRecords)
                .HasForeignKey(x=>x.MemberId).OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new BorrowRecord
            {
                Id = Guid.Parse("c1b2c3d4-0000-0000-0000-000000000001"),
                BookId = bookId,
                MemberId = memberId,
                BorrowedAt = new DateTime(2025, 1, 10),
                ReturnedAt = new DateTime(2025, 1, 20)
            });
        }
    }
}
