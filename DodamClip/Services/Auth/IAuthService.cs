using System.Threading.Tasks;
using DodamClip.Models.DTOs;

namespace DodamClip.Services.Auth
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAsync(LoginDto dto);
        Task<UserDto> LoginAsync(LoginDto dto);
    }
}
