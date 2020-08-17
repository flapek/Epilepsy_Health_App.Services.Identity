using Epilepsy_Health_App.Services.Identity.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Epilepsy_Health_App.Services.Identity.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
    }
}
