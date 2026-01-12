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
                .Where(e => e.UserId == userId)
                .OrderByDescending(e => e.CreatedAt)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}