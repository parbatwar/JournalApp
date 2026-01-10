using JournalApp.Models;
using Microsoft.EntityFrameworkCore;


namespace JournalApp.Services
{
    public class EntryService : IEntryService
    {
        AppDbContext _db;   // database ko reference

        public EntryService(AppDbContext db)
        {
            _db = db;      // constructor bata db aaucha
        }

        public async Task AddEntryAsync(JournalEntry entry)
        {
            _db.Entries.Add(entry);
            await _db.SaveChangesAsync();
        }
    }

}
