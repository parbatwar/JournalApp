using JournalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalApp.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;
        public UserService(AppDbContext db)
        {
            _db = db;
        }

        // Save new user to database
        public async Task RegisterAsync(AppUser user)
        {
            _db.Users.Add(user);            // Add user
            await _db.SaveChangesAsync();            // save
        }

        // Check email and password
        public async Task<AppUser?> LoginAsync(string email, string password)
        {
            return await _db.Users             // Find the user
                .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}
