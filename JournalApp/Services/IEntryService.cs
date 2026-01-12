using JournalApp.Models;

namespace JournalApp.Services
{
    public interface IEntryService
    {
        Task AddEntry(
            JournalEntry entry,
            int primaryMoodId,
            int? secondaryMoodId
        );


        Task<List<JournalEntry>> GetEntries(int userId);
    }
}
