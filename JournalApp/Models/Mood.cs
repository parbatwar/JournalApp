using SQLite;
using System;
using System.ComponentModel.DataAnnotations;

namespace JournalApp.Models
{
    public class Mood
    {
        [PrimaryKey, AutoIncrement]
        public int MoodId { get; set; }
        [Required]
        public string MoodName { get; set; } = "";
        [Required]
        public string MoodCategory { get; set; } = "";


    }
}
