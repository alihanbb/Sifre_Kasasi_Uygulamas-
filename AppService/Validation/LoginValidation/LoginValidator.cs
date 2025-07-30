using AppEntity.Dtos.LoginDto;
using FluentValidation;

namespace AppService.Validation.LoginValidation
{
    public class LoginValidator : AbstractValidator<LoginDtos>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("UserName alanı boş bırakılamaz.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password alanı boş bırakılamaz.");
              
        }
    }
 
}
