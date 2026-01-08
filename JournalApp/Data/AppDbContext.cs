using Microsoft.EntityFrameworkCore;
using JournalApp.Components.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<JournalEntry> Entries { get; set; }
}
