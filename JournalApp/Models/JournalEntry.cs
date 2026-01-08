using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalApp.Models
{
    public class JournalEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JournalId { get; set; }

        public int UserId { get; set; }
        public AppUser? User { get; set; }
        public int TagId { get; set; }
        public Tag? Tag { get; set; }

        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTime EntryDate { get; set; } = DateTime.UtcNow.Date;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<JournalEntryMood>? EntryMoods { get; set; }
    }
}
