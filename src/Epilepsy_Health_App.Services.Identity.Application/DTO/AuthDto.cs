using Newtonsoft.Json;

namespace Epilepsy_Health_App.Services.Identity.Application.DTO
{
    public class AuthDto
    {
        public string AccessToken { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
        public long Expires { get; set; }
    }
}