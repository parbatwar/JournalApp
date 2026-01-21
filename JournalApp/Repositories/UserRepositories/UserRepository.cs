using JournalApp.Models;

namespace JournalApp.Repositories.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db)
    {
        _db = db; // DbContext inject
    }   

    public bool UserExists()
    {
        return _db.Users.Any();
        // single-user app so Any() enough
    }

    public AppUser? GetUser()
    {
        return _db.Users.FirstOrDefault();
        // always first record
    }

    public void Save(AppUser user)
    {
        _db.Users.Add(user);   // insert
        _db.SaveChanges();
    }

}
