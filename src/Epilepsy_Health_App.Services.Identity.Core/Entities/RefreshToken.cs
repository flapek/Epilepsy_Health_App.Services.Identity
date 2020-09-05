using Epilepsy_Health_App.Services.Identity.Core.Exceptions;
using System;

namespace Epilepsy_Health_App.Services.Identity.Core.Entities
{
    public class RefreshToken : AggregateRoot
    {
        public AggregateId UserId { get; private set; }
        public string Token { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? RevokedAt { get; private set; }
        public bool Revoked => DateTime.Compare(DateTime.Now, RevokedAt.Value) > 0 ? true : false;

        protected RefreshToken()
        {
        }

        public RefreshToken(AggregateId id, AggregateId userId, string token, DateTime createdAt,
            DateTime? revokedAt = null)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new EmptyRefreshTokenException();
            }

            Id = id;
            UserId = userId;
            Token = token;
            CreatedAt = createdAt;
            RevokedAt = revokedAt;
        }

        public void Revoke(DateTime revokedAt)
        {
            if (Revoked)
            {
                throw new RevokedRefreshTokenException();
            }

            RevokedAt = revokedAt;
        }
    }
}
