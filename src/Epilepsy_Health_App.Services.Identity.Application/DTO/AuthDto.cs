using Newtonsoft.Json;
using System;

namespace Epilepsy_Health_App.Services.Identity.Application.DTO
{
    public class AuthDto
    {
        public string AccessToken { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
        public DateTime Expires { get; set; }
    }
}