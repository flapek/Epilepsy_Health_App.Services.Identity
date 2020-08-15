namespace Epilepsy_Health_App.Services.Identity.Core.Exceptions
{
    public class InvalidPasswordException : DomainException
    {
        public override string Code { get; } = "invalid_password";

        public InvalidPasswordException() : base($"Invalid password.")
        {
        }
    }
}