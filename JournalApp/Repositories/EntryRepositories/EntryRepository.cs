using JournalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalApp.Repositories.EntryRepositories;

public class EntryRepository : IEntryRepository
{
    private readonly AppDbContext _db;

    public EntryRepository(AppDbContext db)
    {
        _db = db; // DbContext inject
    }

    // Add Entry
    public async Task AddEntry(
        JournalEntry entry,
        int userId,
        int primaryMoodId,
        int? secondaryMoodId
    )
    {
        // Required FK set
        entry.UserId = userId;                 // logged-in user
        entry.CreatedAt = DateTime.UtcNow;     // entry created time
        entry.UpdatedAt = DateTime.UtcNow;     // entry updated time

        // Save entry first (JournalId generate huncha)
        _db.Entries.Add(entry);
        await _db.SaveChangesAsync();

        // Primary mood (required)
        _db.EntryMood.Add(new JournalEntryMood
        {
            JournalId = entry.JournalId,
            MoodId = primaryMoodId,
            MoodRole = MoodRoleEnum.Primary
        });

        // Secondary mood (optional)
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

    // Update Entry
    public async Task UpdateEntry(
        JournalEntry entry,
        int primaryMoodId,
        int? secondaryMoodId
    )
    {
        entry.UpdatedAt = DateTime.UtcNow;

        // Update entry
        _db.Entries.Update(entry);

        // Remove old moods
        var oldMoods = _db.EntryMood
            .Where(m => m.JournalId == entry.JournalId);

        _db.EntryMood.RemoveRange(oldMoods);

        // Re-add primary mood
        _db.EntryMood.Add(new JournalEntryMood
        {
            JournalId = entry.JournalId,
            MoodId = primaryMoodId,
            MoodRole = MoodRoleEnum.Primary
        });

        // Re-add secondary mood (if any)
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

    // Delete Entry
    public async Task DeleteEntry(int entryId)
    {
        var entry = await _db.Entries
            .FirstAsync(e => e.JournalId == entryId);

        _db.Entries.Remove(entry);
        await _db.SaveChangesAsync();
    }


    // Get all journal entries
    public Task<List<JournalEntry>> GetEntries()
        => _db.Entries
            .Include(e => e.EntryMoods)
                .ThenInclude(em => em.Mood)
            .Include(e => e.Tag)
            .OrderByDescending(e => e.EntryDate)
            .ToListAsync();


    // Get single journal entry by its ID
    public Task<JournalEntry?> GetEntryById(int entryId)
        => _db.Entries
            .Include(e => e.EntryMoods)
                .ThenInclude(em => em.Mood)
            .Include(e => e.Tag)
            .FirstOrDefaultAsync(e => e.JournalId == entryId);


    //Get journal entry ID for a specific date
    public Task<int?> GetEntryIdByDate(DateTime date)
        => _db.Entries
            .Where(e => e.EntryDate == date.Date)
            .Select(e => (int?)e.JournalId)
            .FirstOrDefaultAsync();

    //Get all available moods
    public Task<List<Mood>> GetMoods()
        => _db.Moods.AsNoTracking().ToListAsync();

    // Get predefined tags
    public Task<List<Tag>> GetTags()
        => _db.Tags
            .Where(t => t.TagType == TagTypeEnum.Predefined)
            .AsNoTracking()
            .ToListAsync();
}
