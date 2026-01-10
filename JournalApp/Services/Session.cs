using JournalApp.Models;

namespace JournalApp.Services;

public static class Session
{
    public static AppUser? CurrentUser { get; set; }
}
