using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalApp.Models
{   
    public enum MoodCategoryEnum
    {
        Positive,
        Neutral,
        Negative
    }

    public class Mood
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MoodId { get; set; }
        [Required]
        public string MoodName { get; set; } = "";
        [Required]
        public MoodCategoryEnum MoodCategory { get; set; }

        public ICollection<JournalEntryMood>? JournalEntryMoods { get; set; }
    }
}
