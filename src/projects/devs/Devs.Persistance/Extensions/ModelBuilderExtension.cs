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
    }
}
