using JournalApp.Models;
using JournalApp.Repositories.UserRepository;

namespace JournalApp.Services.UserService;

public class UserService : IUserService
{
    // Readonly ensures it cannot be reassigned after initialization
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    // Login logic
    public bool Login(UserDto dto)
    {
        try
        {
            // DTO validation already ensures Username & Password are not empty
            var user = _repo.GetUser();

            //if user does not exist
            if (user == null)
                return false;

            // Credential check
            return user.Username == dto.Username
                && user.Password == dto.Password;
        }
        catch (Exception)
        {
            // Prevent application crash
            return false;
        }
    }

    // Signup logic
    public void SignUp(UserDto dto)
    {
        // Business validation: prevent duplicate user
        if (_repo.UserExists())
            throw new Exception("User already exists");

        var user = new AppUser
        {
            Username = dto.Username,
            Password = dto.Password
        };

        _repo.Save(user);
    }
}
