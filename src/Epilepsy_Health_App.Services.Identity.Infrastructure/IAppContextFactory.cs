using Epilepsy_Health_App.Services.Identity.Application;

namespace Epilepsy_Health_App.Services.Identity.Infrastructure
{
    public interface IAppContextFactory
    {
        IAppContext Create();
    }
}
