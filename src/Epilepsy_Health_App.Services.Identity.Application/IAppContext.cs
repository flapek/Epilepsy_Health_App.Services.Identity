namespace Epilepsy_Health_App.Services.Identity.Application
{
    public interface IAppContext
    {
        string RequestId { get; }
        IIdentityContext Identity { get; }
    }
}
