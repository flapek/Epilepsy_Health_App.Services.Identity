﻿using Epilepsy_Health_App.Services.Identity.Application.DTO;
using Epilepsy_Health_App.Services.Identity.Application.Exceptions;
using Epilepsy_Health_App.Services.Identity.Core.Entities;
using Epilepsy_Health_App.Services.Identity.Core.Exceptions;
using Epilepsy_Health_App.Services.Identity.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Epilepsy_Health_App.Services.Identity.Application.Services.Identity
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IRng _rng;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository,
            IUserRepository userRepository, IJwtProvider jwtProvider, IRng rng)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _rng = rng;
        }

        public async Task<string> CreateAsync(Guid userId)
        {
            var token = _rng.Generate(30, true);
            var refreshToken = new RefreshToken(new AggregateId(), userId, token, DateTime.UtcNow, DateTime.UtcNow.AddDays(7));
            await _refreshTokenRepository.AddAsync(refreshToken);

            return token;
        }

        public async Task RevokeAsync(string refreshToken)
        {
            var token = await _refreshTokenRepository.GetAsync(refreshToken);
            if (token is null)
            {
                throw new InvalidRefreshTokenException();
            }

            token.Revoke(DateTime.UtcNow);
            await _refreshTokenRepository.UpdateAsync(token);
        }

        public async Task<AuthDto> UseAsync(string refreshToken)
        {
            var token = await _refreshTokenRepository.GetAsync(refreshToken);

            if (token is null)
                throw new InvalidRefreshTokenException();

            if (token.Revoked)
                throw new RevokedRefreshTokenException();

            var user = await _userRepository.GetAsync(token.UserId);
            if (user is null)
                throw new UserNotFoundException(token.UserId);

            var auth = _jwtProvider.Create(token.UserId, user.Email);
            await _refreshTokenRepository.UpdateAsync(new RefreshToken(token.Id, token.UserId, token.Token, DateTime.UtcNow, DateTime.UtcNow.AddDays(7)));

            auth.RefreshToken = refreshToken;

            return auth;
        }
    }
}
