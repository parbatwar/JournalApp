using SQLite;
using System.ComponentModel.DataAnnotations;

namespace JournalApp.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; } = "";
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        [Required, EmailAddress]
        public string Email { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
    }
}