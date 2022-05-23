using System.Security.Claims;

namespace MyProject.Models.Security
{
    public class ClaimsBase
    {
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
        public string Response { get; set; }
    }
}
