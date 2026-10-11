namespace Validator.Tests.User.Register;

public class RegisterUserValidatorTests
{
    [Fact]
    public void Success()
    {
        var request = CommonTestUtilities.Request.RequestRegisterUserJsonBuild.build();
    }
}
