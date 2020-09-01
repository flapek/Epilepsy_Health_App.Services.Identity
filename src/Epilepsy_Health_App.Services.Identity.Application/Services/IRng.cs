namespace Epilepsy_Health_App.Services.Identity.Application.Services
{
    public interface IRng
    {
        string Generate(int length = 50, bool removeSpecialChars = false);
    }
}
