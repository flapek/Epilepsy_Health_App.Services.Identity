﻿using Epilepsy_Health_App.Services.Identity.Core.Entities;

namespace Epilepsy_Health_App.Services.Identity.Infrastructure.Mongo.Documents
{
    internal static class Extensions
    {
        public static User AsEntity(this UserDocument document)
            => new User(document.Id, document.Email, document.Password, document.CreatedAt);

        public static UserDocument AsDocument(this User entity)
            => new UserDocument
            {
                Id = entity.Id,
                Email = entity.Email,
                Password = entity.Password,
                CreatedAt = entity.CreatedAt
            };

        public static RefreshToken AsEntity(this RefreshTokenDocument document)
            => new RefreshToken(document.Id, document.UserId, document.Token, document.CreatedAt, document.RevokedAt);

        public static RefreshTokenDocument AsDocument(this RefreshToken entity)
            => new RefreshTokenDocument
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Token = entity.Token,
                CreatedAt = entity.CreatedAt,
                RevokedAt = entity.RevokedAt
            };
    }
}
