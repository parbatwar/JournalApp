using Microsoft.EntityFrameworkCore;
using JournalApp.Models;

namespace JournalApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<JournalEntry> Entries { get; set; }
        public DbSet<JournalEntryMood> EntryMood { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Mood> Moods { get; set; }


        // Seed predefined data (Moods + Tags)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // default EF rules

            // Seed Moods
            modelBuilder.Entity<Mood>().HasData(
                new Mood { MoodId = 1, MoodName = "Happy", MoodCategory = MoodCategoryEnum.Positive },
                new Mood { MoodId = 2, MoodName = "Sad", MoodCategory = MoodCategoryEnum.Negative },
                new Mood { MoodId = 3, MoodName = "Calm", MoodCategory = MoodCategoryEnum.Positive },
                new Mood { MoodId = 4, MoodName = "Anxious", MoodCategory = MoodCategoryEnum.Negative },
                new Mood { MoodId = 5, MoodName = "Neutral", MoodCategory = MoodCategoryEnum.Neutral }
            );

            // Seed Tags
            modelBuilder.Entity<Tag>().HasData(
                new Tag { TagId = 1, TagName = "Work", TagType = TagTypeEnum.Predefined },
                new Tag { TagId = 2, TagName = "Personal", TagType = TagTypeEnum.Predefined },
                new Tag { TagId = 3, TagName = "Health", TagType = TagTypeEnum.Predefined },
                new Tag { TagId = 4, TagName = "Goals", TagType = TagTypeEnum.Predefined }
            );
        }
    }
}
