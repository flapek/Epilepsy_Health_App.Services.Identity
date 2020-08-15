using Epilepsy_Health_App.Services.Identity.Core.Entities;
using System.Threading.Tasks;

namespace Epilepsy_Health_App.Services.Identity.Core.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task AddAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
    }
}
