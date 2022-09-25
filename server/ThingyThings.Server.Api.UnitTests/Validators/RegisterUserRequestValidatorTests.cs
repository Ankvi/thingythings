using FluentValidation.Results;
using ThingyThings.Server.Api.Contract.Requests.Users;
using ThingyThings.Server.Api.Validators;

namespace ThingyThings.Server.Api.UnitTests.Validators;

public class RegisterUserRequestValidatorTests
{
    private readonly RegisterUserRequestValidator _validator;

    public RegisterUserRequestValidatorTests()
    {
        _validator = new RegisterUserRequestValidator();
    }

    [Fact]
    public void no_details_should_fail()
    {
        var input = new RegisterUserRequest();
        var result = _validator.Validate(input);
        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void valid_body_should_succeed()
    {
        var input = new RegisterUserRequest
        {
            Details = new RegisterUserRequestBody
            {
                Email = "test@example.com",
                Password = "kekw",
                ConfirmPassword = "kekw"
            }
        };
        var result = _validator.Validate(input);
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void password_dont_match_should_fail()
    {
        var input = new RegisterUserRequest
        {
            Details = new RegisterUserRequestBody
            {
                Email = "test@example.com",
                Password = "kekw",
                ConfirmPassword = "lmao"
            }
        };
        var result = _validator.Validate(input);
        result.IsValid.Should().BeFalse();
    }

    [Theory]
    [InlineData("", "kek", "kek")]
    [InlineData("test@example.com", "", "kek")]
    [InlineData("test@example.com", "ayy", "")]
    public void missing_data_should_fail(string email, string password, string confirmPassword)
    {
        var input = new RegisterUserRequest
        {
            Details = new RegisterUserRequestBody
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            }
        };

        var result = _validator.Validate(input);
        result.IsValid.Should().BeFalse();
    }

    [Theory]
    [InlineData("test", false)]
    [InlineData("test@test", true)]
    [InlineData("test@test.no", true)]
    public void email_must_be_valid(string email, bool expected)
    {
        var input = new RegisterUserRequest
        {
            Details = new RegisterUserRequestBody
            {
                Email = email,
                Password = "kek",
                ConfirmPassword = "kek"
            }
        };
        var result = _validator.Validate(input);
        result.IsValid.Should().Be(expected);
    }
}
