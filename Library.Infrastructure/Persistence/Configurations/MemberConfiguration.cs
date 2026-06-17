using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Persistence.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public static readonly Guid PrimaryInstructorId = Guid.Parse("a1b2c3d4-0000-0000-0000-000000000001");

        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);

            builder.HasData(new Member
            {
                Id = PrimaryInstructorId,
                FirstName = "Gencay",
                LastName = "Yıldız",
                Email = "gncyldz@gmail.com"
            });
        }
    }
}
