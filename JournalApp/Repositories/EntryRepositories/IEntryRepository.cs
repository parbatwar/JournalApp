using JournalApp.Models;
using JournalApp.Services.EntryService;

namespace JournalApp.Repositories.EntryRepositories;

public interface IEntryRepository
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
