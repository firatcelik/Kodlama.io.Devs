using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;

namespace Devs.Persistence.Configuration
{
    internal class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.HasMany(p => p.Technologies);
        }
    }

    internal static class LanguageSecondConfiguration
    {
        public static ModelBuilder MapLanguage(this ModelBuilder builder2)
        {
            var builder = builder2.Entity<Language>();
            builder.ToTable("Languages").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.HasMany(p => p.Technologies);

            return builder2;
        }
    }

    internal static class OperationSecondConfiguration
    {
        public static ModelBuilder MapOperationClaim(this ModelBuilder builder2)
        {
            var builder = builder2.Entity<OperationClaim>();
            builder.ToTable("OperationClaims").HasKey(o => o.Id);
            builder.Property(o => o.Id).HasColumnName("Id");
            builder.Property(o => o.Name).HasColumnName("Name");

            return builder2;
        }
    }

}
