using AppEntity.Dtos.UserDto;
using FluentValidation;

namespace AppService.Validation.UserValidation
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator() 
        {
            RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage("Id alanı boş bırakılamaz");

            RuleFor(x => x.WebUserName)
                .NotEmpty()
                .WithMessage("Kullanıcı adı boş bırakılamaz");

            RuleFor(x => x.WebSiteName)
                .NotEmpty()
                .WithMessage("Web site ismi boş bırakılamaz.");

            RuleFor(x => x.WebPassword)
                .NotEmpty()
                .WithMessage("Şifre alanı boş bırakılamaz.");

        }
    }
}
