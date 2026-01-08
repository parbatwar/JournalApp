using SQLite;
using System;
using System.ComponentModel.DataAnnotations;

namespace JournalApp.Models
{
    public class Tag
    {
        [PrimaryKey, AutoIncrement]
        public int TagId { get; set; }
        [Required]
        public string TagName { get; set; } = "";
        [Required]
        public string TagType { get; set; } = "";
    }
}
