using JournalApp.Models;
using JournalApp.Services.EntryService;
using Microsoft.EntityFrameworkCore;

namespace JournalApp.Repositories.EntryRepositories;

public class EntryRepository : IEntryRepository
{
    private readonly AppDbContext _db;

    public EntryRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task AddEntry(EntryDto dto)
    {
        // entry create
        var entry = new JournalEntry
        {
            Title = dto.Title,
            Content = dto.Content,
            EntryDate = dto.EntryDate,
            TagId = dto.TagId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        _db.Entries.Add(entry);
        await _db.SaveChangesAsync();

        // primary mood
        _db.EntryMood.Add(new JournalEntryMood
        {
            JournalId = entry.JournalId,
            MoodId = dto.PrimaryMoodId,
            MoodRole = MoodRoleEnum.Primary
        });

        // secondary mood (optional)
        if (dto.SecondaryMoodId != null)
        {
            _db.EntryMood.Add(new JournalEntryMood
            {
                JournalId = entry.JournalId,
                MoodId = dto.SecondaryMoodId.Value,
                MoodRole = MoodRoleEnum.Secondary
            });
        }

        await _db.SaveChangesAsync();
    }

    public async Task UpdateEntry(EntryDto dto)
    {
        var entry = await _db.Entries
            .FirstAsync(e => e.JournalId == dto.JournalId);

        entry.Title = dto.Title;
        entry.Content = dto.Content;
        entry.TagId = dto.TagId;
        entry.UpdatedAt = DateTime.Now;

        // old moods delete
        var moods = _db.EntryMood.Where(m => m.JournalId == entry.JournalId);
        _db.EntryMood.RemoveRange(moods);

        // reinsert moods
        _db.EntryMood.Add(new JournalEntryMood
        {
            JournalId = entry.JournalId,
            MoodId = dto.PrimaryMoodId,
            MoodRole = MoodRoleEnum.Primary
        });

        if (dto.SecondaryMoodId != null)
        {
            _db.EntryMood.Add(new JournalEntryMood
            {
                JournalId = entry.JournalId,
                MoodId = dto.SecondaryMoodId.Value,
                MoodRole = MoodRoleEnum.Secondary
            });
        }

        await _db.SaveChangesAsync();
    }

    public async Task DeleteEntry(int entryId)
    {
        var entry = await _db.Entries.FirstAsync(e => e.JournalId == entryId);
        _db.Entries.Remove(entry);
        await _db.SaveChangesAsync();
    }

    public async Task<List<JournalEntry>> GetEntries()
        => await _db.Entries
            .Include(e => e.EntryMoods)
                .ThenInclude(em => em.Mood)
            .Include(e => e.Tag)
            .OrderByDescending(e => e.EntryDate)
            .ToListAsync();

    public async Task<JournalEntry?> GetEntryById(int entryId)
        => await _db.Entries
            .Include(e => e.EntryMoods)
                .ThenInclude(em => em.Mood)
            .Include(e => e.Tag)
            .FirstOrDefaultAsync(e => e.JournalId == entryId);

    public async Task<int?> GetEntryIdByDate(DateTime date)
        => await _db.Entries
            .Where(e => e.EntryDate == date.Date)
            .Select(e => (int?)e.JournalId)
            .FirstOrDefaultAsync();

    public Task<List<Mood>> GetMoods()
        => _db.Moods.AsNoTracking().ToListAsync();

    public Task<List<Tag>> GetTags()
        => _db.Tags
            .Where(t => t.TagType == TagTypeEnum.Predefined)
            .AsNoTracking()
            .ToListAsync();
}
