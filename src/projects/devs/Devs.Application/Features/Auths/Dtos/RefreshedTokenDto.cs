using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;
using Core.Security.JWT;
using Devs.Application.Features.Languages.Queries.GetByIdLanguage;

namespace Devs.Application.Features.Auths.Dtos
{
    public class RefreshedTokenDto
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
