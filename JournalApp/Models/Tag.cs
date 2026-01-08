using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalApp.Models
{
    public enum TagTypeEnum
    {
        Custom,
        Predefined,
    }
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }
        [Required]
        public string TagName { get; set; } = "";
        [Required]
        public TagTypeEnum TagType { get; set; }

        public ICollection<JournalEntry>? JournalEntries { get; set; }

    }
}
