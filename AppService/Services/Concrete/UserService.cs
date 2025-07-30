using AppData.Repositories;
using AppData.UnitOfWorks;
using AppEntity.Dtos.UserDto;
using AppEntity.Entities;
using AppService.Services.Abstract;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppService.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IRepository<User> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateUserDto createUserDto)
        {
            var user = mapper.Map<User>(createUserDto);
            await repository.AddAsync(user);
            await unitOfWork.SaveChangesAsync();

        }

        public async Task DeleteAsync(Guid id)
        {
            var anyUser = await repository.GetByIdAsync(id);
            await repository.DeleteAsync(anyUser.Id);
            await unitOfWork.SaveChangesAsync();

        }

        public async Task<List<ResultUserDto>> GetAllAsync()
        {
            var users = await repository.GetAll().ToListAsync();
            var result = mapper.Map<List<ResultUserDto>>(users);
            return result;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var anyUser = await repository.GetByIdAsync(id);
            var userMap = mapper.Map<User>(anyUser);
            return userMap;
        }

        public async Task UpdatesAsync(UpdateUserDto updateUserDto)
        {
            var user = await repository.GetByIdAsync(updateUserDto.Id);
            var userMap = mapper.Map(updateUserDto, user);
            await repository.UpdateAsync(userMap);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
