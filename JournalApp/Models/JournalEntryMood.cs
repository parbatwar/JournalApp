using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalApp.Models
{   
    public enum MoodRoleEnum
    {
        Primary,
        Secondary
    }
    public class JournalEntryMood
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JournalEntryMoodId { get; set; }
        [Required]
        public int JournalId { get; set; }
        public JournalEntry? JournalEntry { get; set; }
        [Required]
        public int MoodId { get; set; }
        public Mood? Mood { get; set; }
        [Required]
        public MoodRoleEnum MoodRole { get; set; }

    }
}


