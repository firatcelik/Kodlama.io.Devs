using Core.Security.Entities;
using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedLanguage(this ModelBuilder builder)
        {
            builder.Entity<Language>().HasData(new(1, "C#"), new(2, "Java"));
        }

        public static void SeedTechnology(this ModelBuilder builder)
        {
            Technology[] modelTechnologies = { new(1, 1, "WPF"), new(2, 1, "ASP.NET"), new(3, 2, "Spring"), new(4, 2, "JSP") };

            builder.Entity<Technology>().HasData(modelTechnologies);
        }

        public static void SeedOperationClaim(this ModelBuilder builder)
        {
            OperationClaim[] operationClaimsEntitySeeds =
            {
                new(1, "Admin"),
                new(2, "User")
            };

            builder.Entity<OperationClaim>().HasData(operationClaimsEntitySeeds);
        }
    }
}
