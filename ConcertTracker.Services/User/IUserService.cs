using ConcertTracker.Models.User;

namespace ConcertTracker.Services.User;

public interface IUserService
{
    Task<bool> RegisterUserAsync(UserRegister model);
    Task<bool> LoginAsync(UserLogin model);
    Task LogoutAysnc();
}