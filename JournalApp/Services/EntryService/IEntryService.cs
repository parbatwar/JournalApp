using JournalApp.Models;

namespace JournalApp.Services.EntryService;

public interface IEntryService
{
    Task AddEntry(EntryDto dto);
    Task UpdateEntry(EntryDto dto);
    Task DeleteEntry(int entryId);

    Task<List<JournalEntry>> GetEntries();
    Task<JournalEntry?> GetEntryById(int entryId);
    Task<int?> GetEntryIdByDate(DateTime date);

    Task<List<Mood>> GetMoods();
    Task<List<Tag>> GetTags();
}
