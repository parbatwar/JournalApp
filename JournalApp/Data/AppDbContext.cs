using Microsoft.EntityFrameworkCore;
using JournalApp.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<JournalEntry> Entries { get; set; }
    public DbSet<JournalEntryMood> EntryMood { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Mood> Moods { get; set; }
}
