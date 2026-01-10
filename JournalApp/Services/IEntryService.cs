using JournalApp.Models;

namespace JournalApp.Services
{
    public interface IEntryService
    {
        Task AddEntryAsync(JournalEntry entry);
    }
}
