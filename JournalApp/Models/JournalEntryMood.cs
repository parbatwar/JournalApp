using SQLite;
using System;
using System.ComponentModel.DataAnnotations;

namespace JournalApp.Models
{
    public class JournalEntryMood
    {
        [PrimaryKey, AutoIncrement]
        public int JournalEntryMoodId { get; set; }
        public int JournalId { get; set; }
        public int MoodId { get; set; }
        [Required]
        public string MoodRole { get; set; } = "";
    }
}


