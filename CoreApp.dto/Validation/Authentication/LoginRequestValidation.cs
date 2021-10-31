using CoreApp.dto.Request.Authentication;
using FluentValidation;

namespace CoreApp.Dto.Validation
{
    public class LoginRequestValidation : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidation()
        {
            RuleFor(c => c.Username).NotEmpty();
            RuleFor(c => c.Password).NotEmpty();
        }
    }
}
