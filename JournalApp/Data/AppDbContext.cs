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
        public object AppUsers { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Mood>().HasData(
                new Mood { MoodId = 1, MoodName = "Happy", MoodCategory = MoodCategoryEnum.Positive },
                new Mood { MoodId = 2, MoodName = "Excited", MoodCategory = MoodCategoryEnum.Positive },
                new Mood { MoodId = 3, MoodName = "Grateful", MoodCategory = MoodCategoryEnum.Positive },
                new Mood { MoodId = 4, MoodName = "Relaxed", MoodCategory = MoodCategoryEnum.Positive },
                new Mood { MoodId = 5, MoodName = "Sad", MoodCategory = MoodCategoryEnum.Negative },
                new Mood { MoodId = 6, MoodName = "Anxious", MoodCategory = MoodCategoryEnum.Negative },
                new Mood { MoodId = 7, MoodName = "Angry", MoodCategory = MoodCategoryEnum.Negative },
                new Mood { MoodId = 8, MoodName = "Calm", MoodCategory = MoodCategoryEnum.Neutral },
                new Mood { MoodId = 9, MoodName = "Thoughtful", MoodCategory = MoodCategoryEnum.Neutral },
                new Mood { MoodId = 10, MoodName = "Curious", MoodCategory = MoodCategoryEnum.Neutral }
            );


            modelBuilder.Entity<Tag>().HasData(
                new Tag { TagId = 1, TagName = "Work", TagType = TagTypeEnum.Predefined },
                new Tag { TagId = 2, TagName = "Personal", TagType = TagTypeEnum.Predefined },
                new Tag { TagId = 3, TagName = "Health", TagType = TagTypeEnum.Predefined },
                new Tag { TagId = 4, TagName = "Goals", TagType = TagTypeEnum.Predefined },
                new Tag { TagId = 5, TagName = "Birthday", TagType = TagTypeEnum.Predefined }
            );
        }
    }
}
