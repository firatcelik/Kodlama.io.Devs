using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Configuration
{
    internal class UserSocialMediaAddressConfiguration : IEntityTypeConfiguration<UserSocialMediaAddress>
    {
        public void Configure(EntityTypeBuilder<UserSocialMediaAddress> builder)
        {
            builder.ToTable("UserSocialMediaAddresses").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.GithubUrl).HasColumnName("GithubUrl");

            builder.HasOne(x => x.User);
        }
    }
}
