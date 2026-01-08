using SQLite;
using System;
using System.ComponentModel.DataAnnotations;

namespace JournalApp.Models
{
    public class JournalEntry
    {
        [PrimaryKey, AutoIncrement]
        public int JournalId { get; set; }
        public int UserId { get; set; }
        public int TagId { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
