using JournalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalApp.Data
{
    public static class DataSeeder
    {
        public static async Task SeedEntriesAsync(AppDbContext db)
        {
            // -----------------------------
            // 1️⃣ DEMO USER create (if none)
            // -----------------------------
            if (!await db.Users.AnyAsync())
            {
                var demoUser = new AppUser
                {
                    Username = "demo",
                    Password = "123" // ⚠️ testing only
                };

                db.Users.Add(demoUser);
                await db.SaveChangesAsync();
            }

            // now safe to fetch user
            var user = await db.Users.FirstAsync();

            // --------------------------------
            // 2️⃣ If entries already exist → stop
            // --------------------------------
            if (await db.Entries.AnyAsync())
                return;

            var random = new Random();

            var sampleTitles = new[]
            {
                "A productive day",
                "Feeling grateful",
                "Stress at work",
                "Relaxing evening",
                "Small wins today",
                "Health check-in",
                "Thinking about future",
                "Good conversations",
                "Calm and focused",
                "Learning something new"
            };

            var sampleContents = new[]
            {
                "Today I felt really positive and focused.",
                "Work was stressful but manageable.",
                "I enjoyed a calm and relaxing evening.",
                "Grateful for small things in life.",
                "Learned something new today."
            };

            var moods = await db.Moods.ToListAsync();
            var tags = await db.Tags.ToListAsync();

            // -----------------------------
            // 3️⃣ Create 10 demo entries
            // -----------------------------
            for (int i = 0; i < 10; i++)
            {
                var entry = new JournalEntry
                {
                    UserId = user.UserId,
                    Title = sampleTitles[i],
                    Content = sampleContents[random.Next(sampleContents.Length)],
                    TagId = tags[random.Next(tags.Count)].TagId,
                    EntryDate = DateTime.UtcNow.Date.AddDays(-i),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                db.Entries.Add(entry);
                await db.SaveChangesAsync(); // JournalId generate huncha

                // primary mood (required)
                var primaryMood = moods[random.Next(moods.Count)];

                db.EntryMood.Add(new JournalEntryMood
                {
                    JournalId = entry.JournalId,
                    MoodId = primaryMood.MoodId,
                    MoodRole = MoodRoleEnum.Primary
                });

                // secondary mood (50% chance)
                if (random.Next(2) == 1)
                {
                    var secondaryMood = moods[random.Next(moods.Count)];

                    db.EntryMood.Add(new JournalEntryMood
                    {
                        JournalId = entry.JournalId,
                        MoodId = secondaryMood.MoodId,
                        MoodRole = MoodRoleEnum.Secondary
                    });
                }

                await db.SaveChangesAsync();
            }
        }
    }
}
