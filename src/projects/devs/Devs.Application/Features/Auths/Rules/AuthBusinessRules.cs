using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Devs.Application.Features.Users.Constants;
using Devs.Application.Services.Repositories;

namespace Devs.Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            var user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException(UserMessages.EmailAddressAlreadyExist);
        }
    }
}
