using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Entity
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = "Admin";
    }
}
