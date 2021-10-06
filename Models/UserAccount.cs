using System.ComponentModel.DataAnnotations;

namespace InternetPcPartDatabase.Models
{
    public class UserAccount
    {
        [Key]
        public int UserAccountId {  get; set; }

        [Required]
        public string? Email {  get; set; }

        [Required]
        public string? Password {  get; set; }
    }
}
