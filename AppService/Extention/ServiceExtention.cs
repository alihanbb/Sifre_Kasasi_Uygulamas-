using System.Reflection;
using AppEntity.Dtos.LoginDto;
using AppEntity.Dtos.RegisterDto;
using AppEntity.Dtos.UserDto;
using AppService.Mapping;
using AppService.Services.Abstract;
using AppService.Services.Concrete;
using AppService.Validation.LoginValidation;
using AppService.Validation.RegisterValidation;
using AppService.Validation.UserValidation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AppService.Extention
{
    public static class ServiceExtention
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();

            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(UserMapping).Assembly);
            services.AddAutoMapper(typeof(RegisterMapping).Assembly);

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient<IValidator<CreateUserDto>, CreateUserValidator>();
            services.AddTransient<IValidator<UpdateUserDto>, UpdateUserValidator>();
            services.AddTransient<IValidator<RegisterDtos>, RegisterValidator>();
            services.AddTransient<IValidator<LoginDtos>, LoginValidator>();
     


            return services;
        }
    }
}
