using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Devs.Persistence.Configuration
{
    internal class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("RefreshTokens").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.UserId).HasColumnName("UserId");
            builder.Property(p => p.Token).HasColumnName("Token");
            builder.Property(p => p.Expires).HasColumnName("Expires");
            builder.Property(p => p.Created).HasColumnName("Created");
            builder.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
            builder.Property(p => p.Revoked).HasColumnName("Revoked");
            builder.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
            builder.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
            builder.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");

            builder.HasOne(p => p.User);
        }
    }
}
