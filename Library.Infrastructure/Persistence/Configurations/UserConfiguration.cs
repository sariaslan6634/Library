using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PasswordHash).IsRequired();

            builder.HasData(new User
            {
                Id = Guid.Parse("a1b2c3d4-0000-0000-0000-000000000001"),
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@gmail.com",
                PasswordHash = ""
            },
            new User
            {
                Id = Guid.Parse("a1b2c3d4-0000-0000-0000-000000000002"),
                FirstName = "Ibrahim",
                LastName = "SARIASLAN",
                Email = "ibrahim@gmail.com",
                PasswordHash = ""
            });
        }
    }
}
