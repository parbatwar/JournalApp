namespace JournalApp.Services.UserService;

public interface IUserService
{
    bool Login(UserDto dto);   // login
    void SignUp(UserDto dto);  // signup (one time)
}
