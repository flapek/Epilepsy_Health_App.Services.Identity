using Joint.CQRS.Commands;
using System.ComponentModel.DataAnnotations;

namespace Epilepsy_Health_App.Services.Identity.Application.Commands
{
    public class SignOut : ICommand
    {
        public string RefreshToken{ get; set; }
    }
}
