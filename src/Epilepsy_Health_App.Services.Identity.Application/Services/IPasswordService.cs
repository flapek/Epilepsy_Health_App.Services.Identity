namespace Epilepsy_Health_App.Services.Identity.Application.Services
{
    public interface IPasswordService
    {
        bool IsValid(string hash, string password);
        string Hash(string password);
    }
}
