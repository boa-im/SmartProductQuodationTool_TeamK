using System.ComponentModel.DataAnnotations;

namespace SmartProductQuotationTool.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255)]
        public string? UserName { get; set; }


        [Required(ErrorMessage = "Please enter a password.")]
        [StringLength(255)]
        public string? Password { get; set; }
        public string? ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}