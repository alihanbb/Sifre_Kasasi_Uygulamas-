using AppEntity.Dtos.RegisterDto;
using FluentValidation;

namespace AppService.Validation.RegisterValidation
{
    public class RegisterValidator : AbstractValidator<RegisterDtos>
    {
        public RegisterValidator()
        {
             RuleFor(r=>r.Name)
                .NotEmpty()
                .WithMessage("İsim alanı boş bırakılamaz");

             RuleFor(r=>r.SurName)
                .NotEmpty()
                .WithMessage("Soyisim alanı boş bırakılamaz");

             RuleFor(r=>r.Email)
                .NotEmpty()
                .WithMessage("Email alanı boş bırakılamaz")
                .EmailAddress()
                .WithMessage("Geçerli bir email adresi giriniz");

            RuleFor(r => r.UserName)
                .NotEmpty()
                .WithMessage("Kullanıcı adı alanı boş bırakılamaz");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Şifre alanı boş bırakılamaz")
                .MinimumLength(6)
                .WithMessage("Şifre en az 6 karakter olmalıdır");

            RuleFor(r => r.PasswordConfirm)
                .NotEmpty()
                .WithMessage("Şifre onay alanı boş bırakılamaz")
                .Equal(r => r.Password)
                .NotEmpty()
                .WithMessage("Şifreler uyuşmuyor");
        }
    }
    
}
