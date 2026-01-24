using JournalApp.Models;

namespace JournalApp.Services.EntryService;

public interface IEntryService
{
    Task AddEntry(JournalEntry entry, int userId, int primaryMoodId, int? secondaryMoodId);
    Task UpdateEntry(JournalEntry entry, int primaryMoodId, int? secondaryMoodId);
    Task DeleteEntry(int entryId);

    Task<List<JournalEntry>> GetEntries();
    Task<JournalEntry?> GetEntryById(int entryId);
    Task<int?> GetEntryIdByDate(DateTime date);

    Task<List<Mood>> GetMoods();
    Task<List<Tag>> GetTags();
}
