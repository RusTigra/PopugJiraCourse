using System.ComponentModel.DataAnnotations;

namespace AuthService.Models
{
    public class AuthViewModel
    {
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        public string ReturnUrl { get; set; }

        public string Token { get; set; }
    }
}
