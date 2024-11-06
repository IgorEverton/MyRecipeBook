using FluentValidation;
using MyRecipeBook.Communication.Request;
using MyRecipeBook.Exceptions;

namespace MyRecipeBook.Application.UseCases.User.Register;

internal class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagensException.NAME_EMPTY);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessagensException.EMAIL_EMPTY);
        RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagensException.EMAIL_INVALID);
        RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessagensException.PASSWORD_MIN_CARAC);
    }
}
