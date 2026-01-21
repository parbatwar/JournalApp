using JournalApp.Models;

namespace JournalApp.Repositories.UserRepository;

public interface IUserRepository
{
    bool UserExists();          // user banisakyo ki chaina
    AppUser? GetUser();         // single user fetch
    void Save(AppUser user);    // insert / update
}
