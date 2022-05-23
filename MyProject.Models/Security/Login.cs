using System.ComponentModel.DataAnnotations;

namespace MyProject.Models.Security
{
    public class Login
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }

    }
}
