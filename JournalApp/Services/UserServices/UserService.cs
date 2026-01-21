using JournalApp.Models;
using JournalApp.Repositories.UserRepository;

namespace JournalApp.Services.UserService;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    public bool Login(UserDto dto)
    {
        var user = _repo.GetUser();

        if (user == null)
            return false;

        return user.Username == dto.Username
            && user.Password == dto.Password;
    }

    public void SignUp(UserDto dto)
    {
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
