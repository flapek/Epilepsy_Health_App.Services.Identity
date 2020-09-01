using Epilepsy_Health_App.Services.Identity.Application.DTO;
using Joint.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epilepsy_Health_App.Services.Identity.Application.Commands
{
    public class SignIn : ICommand<AuthDto>
    {
    }
}
