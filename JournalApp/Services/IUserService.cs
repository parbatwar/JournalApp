using JournalApp.Models;

namespace JournalApp.Services
{
    public interface IUserService
    {
        // Register new user
        Task RegisterAsync(AppUser user);

        // Login using email and password
        Task<AppUser?> LoginAsync(string email, string password);
    }
}
 