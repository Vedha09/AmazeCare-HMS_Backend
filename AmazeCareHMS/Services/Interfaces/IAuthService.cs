using AmazeCareHMS.DTOs.Auth;

namespace AmazeCareHMS.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginAsync(UserLoginDto dto);
        Task<bool> RegisterAsync(UserRegisterDto dto);
    }
}
