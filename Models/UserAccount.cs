using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InternetPcPartDatabase.Models
{
    public class UserAccount
    {
        [Key]
        public int UserAccountId {  get; set; }

        [Required]
        public string? Username { get; set; }
        
        [Required]
        public string? Email {  get; set; }

        [Required]
        public string? Password {  get; set; }
    }

    [Keyless]
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "Email Address is too long.")]
        public string Email {  get; set; }

        [Compare(nameof(Email))]
        [Display(Name = "Confirm E-Mail")]
        public string ConfirmEmail {  get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least eight characters and no longer than 100 characters.")]
        public string Password {  get; set; }

        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword {  get; set; }
    }

    [Keyless]
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [StringLength(200)]
        public string Email {  get; set; }

        [Required]
        [StringLength(100)]
        public string Password {  get; set; }
    }
}
