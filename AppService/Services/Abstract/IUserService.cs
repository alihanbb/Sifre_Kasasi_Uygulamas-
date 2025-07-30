using AppEntity.Dtos.UserDto;
using AppEntity.Entities;

namespace AppService.Services.Abstract
{
    public interface IUserService
    {
        Task CreateAsync(CreateUserDto createUserDto);
        Task UpdatesAsync(UpdateUserDto updateUserDto);
        Task<User> GetByIdAsync(Guid id);
        Task<List<ResultUserDto>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}
