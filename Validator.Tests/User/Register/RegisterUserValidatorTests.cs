using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Exceptions;
using Shouldly;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Validator.Tests.User.Register;

public class RegisterUserValidatorTests
{
    [Fact]
    public void Success()
    {
        var request = CommonTestUtilities.Request.RequestRegisterUserJsonBuild.build();

        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeTrue();
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenNameIsEmpty()
    {
        var request = CommonTestUtilities.Request.RequestRegisterUserJsonBuild.build();
        request.Name = string.Empty;

        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();

        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
            errors.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessagensException.NAME_EMPTY));
        });
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenEmailIsEmpty()
    {
        var request = CommonTestUtilities.Request.RequestRegisterUserJsonBuild.build();
        request.Email = string.Empty;

        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();

        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
            errors.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessagensException.EMAIL_EMPTY));
        });
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenPasswordIsEmpty()
    {
        var request = CommonTestUtilities.Request.RequestRegisterUserJsonBuild.build();
        request.Password = string.Empty;

        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();

        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
            errors.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessagensException.PASSWORD_MIN_CARAC));
        });
    }
}
