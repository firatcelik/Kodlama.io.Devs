using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Devs.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Devs.Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;


        public AuthManager(IUserOperationClaimRepository userOperationClaimRepository,
            ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(
                u => u.UserId == user.Id,
                include: u =>
                    u.Include(u => u.OperationClaim)
            );

            IList<OperationClaim> operationClaims =
                userOperationClaims.Items.Select(u=>new OperationClaim
                {
                    Id=u.OperationClaim.Id,
                    Name = u.OperationClaim.Name
                }).ToList();

            var accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }

        public async Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
        {
            var refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            return await Task.FromResult(refreshToken);
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            var addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
            return addedRefreshToken;
        }
    }
}
