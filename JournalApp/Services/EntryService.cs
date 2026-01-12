using JournalApp.Models;
using Microsoft.EntityFrameworkCore;


namespace JournalApp.Services
{
    public class EntryService : IEntryService
    {
        private readonly AppDbContext _db;   // database ko reference

        public EntryService(AppDbContext db)
        {
            _db = db;      // constructor bata db aaucha
        }

        public async Task AddEntry(
               JournalEntry entry,
               int primaryMoodId,
               int? secondaryMoodId)
        {
            _db.Entries.Add(entry);
            await _db.SaveChangesAsync();

            _db.EntryMood.Add(new JournalEntryMood
            {
                JournalId = entry.JournalId,
                MoodId = primaryMoodId,
                MoodRole = MoodRoleEnum.Primary
            });

            if (secondaryMoodId.HasValue)
            {
                _db.EntryMood.Add(new JournalEntryMood
                {
                    JournalId = entry.JournalId,
                    MoodId = secondaryMoodId.Value,
                    MoodRole = MoodRoleEnum.Secondary
                });
            }

            await _db.SaveChangesAsync();
        }


        // logged-in user ko sabai entries
        public async Task<List<JournalEntry>> GetEntries(int userId)
                {
                    return await _db.Entries
                        .Include(e => e.EntryMoods)
                            .ThenInclude(em => em.Mood)   // 🔥 THIS WAS MISSING
                        .Include(e => e.Tag)
                        .Where(e => e.UserId == userId)
                        .OrderByDescending(e => e.EntryDate)
                        .ToListAsync();
                }

        public async Task<JournalEntry> GetEntryById(int entryId)
        {
            return await _db.Entries
                .FirstAsync(e => e.JournalId == entryId);
        }


        public async Task DeleteEntry(int journalId)
        {
            var entry = await _db.Entries
                .FirstAsync(e => e.JournalId == journalId); // assumes always exists

            _db.Entries.Remove(entry);
            await _db.SaveChangesAsync();
        }



    }
}