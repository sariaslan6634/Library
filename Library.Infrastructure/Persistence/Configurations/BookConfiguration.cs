using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(x=>x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x=>x.Writer).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.PageNumber).HasColumnType("integer");

            builder.HasData(new Book
            {
                Id = Guid.Parse("b1b2c3d4-0000-0000-0000-000000000001"),
                Title = "Suç ve Ceza",
                Description = "Dostoyevski'nin başyapıtı",
                Writer = "Fyodor Dostoyevski",
                PageNumber = 671,
                IsAvailable = true
            },
            new Book
            {
                Id = Guid.Parse("b1b2c3d4-0000-0000-0000-000000000002"),
                Title = "1984",
                Description = "Distopik bir gelecek hikayesi",
                Writer = "George Orwell",
                PageNumber = 328,
                IsAvailable = false
            });
        }
    }
}
