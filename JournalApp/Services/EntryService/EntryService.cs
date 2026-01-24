using JournalApp.Models;
using JournalApp.Repositories.EntryRepositories;

namespace JournalApp.Services.EntryService;

public class EntryService : IEntryService
{
    private readonly IEntryRepository _repo;

    public EntryService(IEntryRepository repo)
    {
        _repo = repo; // repository inject
    }

    public Task AddEntry(
        JournalEntry entry,
        int userId,
        int primaryMoodId,
        int? secondaryMoodId
    )
        => _repo.AddEntry(entry, userId, primaryMoodId, secondaryMoodId);

    public Task UpdateEntry(
        JournalEntry entry,
        int primaryMoodId,
        int? secondaryMoodId
    )
        => _repo.UpdateEntry(entry, primaryMoodId, secondaryMoodId);

    public Task DeleteEntry(int entryId)
        => _repo.DeleteEntry(entryId);

    public Task<List<JournalEntry>> GetEntries()
        => _repo.GetEntries();

    public Task<JournalEntry?> GetEntryById(int entryId)
        => _repo.GetEntryById(entryId);

    public Task<int?> GetEntryIdByDate(DateTime date)
        => _repo.GetEntryIdByDate(date);

    public Task<List<Mood>> GetMoods()
        => _repo.GetMoods();

    public Task<List<Tag>> GetTags()
        => _repo.GetTags();
}
